using Logik;
using System;
using System.Collections.Generic;
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

namespace Frontend
{
    /// <summary>
    /// Interaktionslogik für HighScorePage.xaml
    /// </summary>
    public partial class HighScorePage : Page
    {
        CSVManager csvManager = new();

        /// <summary>
        /// After the InitializeComponents method the data from the CSV File gets added to the DataGrid
        /// </summary>
        public HighScorePage()
        {
            InitializeComponent();
            dgHighScore.ItemsSource = csvManager.GetScores();
        }
    }
}
