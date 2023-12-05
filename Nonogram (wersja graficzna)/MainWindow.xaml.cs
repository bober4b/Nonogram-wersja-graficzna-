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


namespace Nonogram__wersja_graficzna_
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            // Handle the New Game button click
            // You can add the logic for starting a new game here
        }

        private void LoadGame_Click(object sender, RoutedEventArgs e)
        {
            // Handle the Load Game button click
            // You can add the logic for loading a game here
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            // Handle the Exit button click
            Close();
        }


    }
}
