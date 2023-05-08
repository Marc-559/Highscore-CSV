using CsvHelper;
using System;
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
using static System.Net.Mime.MediaTypeNames;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Navigates to the HighScorePage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuHighScore(object sender, RoutedEventArgs e)
        {
            Navigation.Navigate(new HighScorePage());
        }

        /// <summary>
        /// Navigates to the the AddScorePage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAddScore(object sender, RoutedEventArgs e)
        {
            Navigation.Navigate(new AddScorePage());
        }
    }
}
