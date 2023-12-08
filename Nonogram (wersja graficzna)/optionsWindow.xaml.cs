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
    /// Logika interakcji dla klasy optionsWindow.xaml
    /// </summary>
    public partial class optionsWindow : UserControl
    {
        public optionsWindow()
        {
            InitializeComponent();
            guideinit();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            parentWindow.Content = new MainMenu();
        }
        private void guideinit()
        {
            guide.Text = "Po uruchomienu gry, widoczna będzie plansza z 100 polami (10x10).\nKlikaj lewym przyciskiem myszy, aby zaznaczać pola.\n" +
                "Jeżeli pole będzie poprawne, pole zmieni kolor na niebieski, jeśli jednak nie, to na polu pojawi się X.\n" +
                "Klikając prawym przyciskiem myszy, zmieniasz kolor na zielony.\nBłędne odpowiedzi oznaczają się czerwony X. " +
                "Cyfry Widoczne w górnym i lewym rogu planszy to podpowiedzi.\nKorzystaj z nich aby odpowiadać poprawnie.\n" +
                "Progres gry i liczba błędów są widoczne na po prawej stronie planszy.\n" +
                "Naciśnij Escape, aby ukryć/pokazać menu.\n";
        }
    }
}
