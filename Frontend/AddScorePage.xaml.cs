using CsvHelper;
using Data;
using Logic;
using Logik;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Frontend
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class AddScorePage : Page
    {
        
        CSVManager cSVManager = new CSVManager();
        public AddScorePage()
        {
            InitializeComponent();
            datePicker.SelectedDate = DateTime.Now.Date;
            List<Score> scores = cSVManager.GetScores();

            List<Score> scoresPN = new List<Score>();
            var seenNames = new HashSet<string>();

            foreach (var score in scores)
            {
                //If Playername is already in the list dont add it
                if (seenNames.Contains(score.PlayerName))
                {
                    continue; // Skip duplicates
                }

                seenNames.Add(score.PlayerName);
                scoresPN.Add(score);
            }
           
            cbPlayerName.ItemsSource = scoresPN; 
            cbPlayerName.DisplayMemberPath = "PlayerName";

            //ChatGPT:
            //This LINQ gets all the scores and groups them by their VideoGameName if the VideoGameName is not a duplicate it will write it in the comboBox
            //if it is a Duplicate it will write it in the comboBox in the first time but
            //if the Name comes again it will not be written in the comboBox
            cbVideoGameName.ItemsSource = scores.GroupBy(o => o.VideoGameName).SelectMany(g => g.Count() == 1 ? g : g.Take(1));
            cbVideoGameName.DisplayMemberPath = "VideoGameName";
        }

        /// <summary>
        /// Creates a new score with the textboxes in the Page. 
        /// Then the new score gets validated and if correct added to the CSV File.
        /// After the score got added to the CSV File the program switches to the HighScorePage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddScore(object sender, RoutedEventArgs e)
        {
            ScoreValidation validation = new();
            try
            {

                Score score = new Score
                {
                    PlayerName = cbPlayerName.Text,
                    VideoGameName = cbVideoGameName.Text,
                    HighScore = txtHighScore.Text,
                    Date = datePicker.SelectedDate.Value,
                    Comment = txtComment.Text
                };

                validation.Validate(score);         //Validating created Object

                cSVManager.AddScoreToCSV(score);    // Adding Created Object to the CSV File
                
                (Application.Current.MainWindow as MainWindow).Navigation.Navigate(new HighScorePage()); //Opens the Highscore Page after the score is added
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
