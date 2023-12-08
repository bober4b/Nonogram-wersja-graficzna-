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
    /// Logika interakcji dla klasy UserControl1.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        private void NewGame_Click(object sender, RoutedEventArgs e)
        {




            Buttons.Visibility = Visibility.Collapsed;
            h1.Visibility = Visibility.Collapsed;
            MainContent.Content = new Game();


        }

        private void LoadGame_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            parentWindow.Content = new Game(true);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

            Window parentWindow=Window.GetWindow(this);
            if(parentWindow != null) { parentWindow.Close(); }
        }

        private void Options_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            parentWindow.Content = new optionsWindow();
        }
    }
}
