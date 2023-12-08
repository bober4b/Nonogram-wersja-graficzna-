using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Nonogram.controls;
using Nonogram.models;

namespace Nonogram__wersja_graficzna_
{
    /// <summary>
    /// Logika interakcji dla klasy Game.xaml
    /// </summary>
    public partial class Game : UserControl
    {
        private Gra gameControl;
        private Scoremodule scoremodule;
        public Game()
        {
            InitializeComponent();
            InitializeField();
            CreateButtonGrid();
            Hinttop();
            Hintleft();
            scoreupdate();
        }
        public Game(bool load)
        {
            InitializeComponent();
            loadfield();
            CreateButtonGridfromLoad();
            Hinttop();
            Hintleft();
            scoreupdate();
        }

        

        private void CreateButtonGrid()
        {
            for (int i = 0; i < 10; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = GridLength.Auto;
                buttonGrid.RowDefinitions.Add(rowDef);

                ColumnDefinition colDef = new ColumnDefinition();
                colDef.Width = GridLength.Auto;
                buttonGrid.ColumnDefinitions.Add(colDef);
            }

            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    Button button = new Button
                    {
                        //button.Click += Button_Click;
                        Width = 20,
                        Height = 20,
                        Name = $"field_{row}_{col}"
                    };

                    RadialGradientBrush gradientBrush = new RadialGradientBrush
                    {
                        GradientOrigin = new Point(0.5, 0.5),
                        Center = new Point(0.5, 0.5),
                        RadiusX = 1.1,
                        RadiusY = 1.1
                    };



                    gradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(0xFF, 0xC4, 0xE1, 0xEF), 0.0));
                    gradientBrush.GradientStops.Add(new GradientStop(Colors.Black, 1.0));

                    button.Background = gradientBrush;

                    button.BorderBrush= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC3C3C3"));
                   
                    //button.MouseLeftButtonDown += Button_Click_Left;
                    button.Click += Button_Click_Left;
                    button.MouseRightButtonDown += Button_MouseRightButtonDown; ;
                    




                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);

                    buttonGrid.Children.Add(button);
                }
            }
        }
        private void CreateButtonGridfromLoad()
        {
            for (int i = 0; i < 10; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = GridLength.Auto;
                buttonGrid.RowDefinitions.Add(rowDef);

                ColumnDefinition colDef = new ColumnDefinition();
                colDef.Width = GridLength.Auto;
                buttonGrid.ColumnDefinitions.Add(colDef);
            }

            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    Button button = new Button
                    {
                        //button.Click += Button_Click;
                        Width = 20,
                        Height = 20,
                        Name = $"field_{row}_{col}"
                    };

                    RadialGradientBrush gradientBrush = new RadialGradientBrush
                    {
                        GradientOrigin = new Point(0.5, 0.5),
                        Center = new Point(0.5, 0.5),
                        RadiusX = 1.1,
                        RadiusY = 1.1
                    };

                    if (gameControl.field[row,col].Answer()) 
                    {
                        if (gameControl.field[row,col].Get_answer())
                        {
                            if (gameControl.field[row,col].Getcolor())
                            {
                                gradientBrush.GradientStops.Add(new GradientStop(Colors.DarkCyan, 0.0));
                                gradientBrush.GradientStops.Add(new GradientStop(Colors.Black, 1.0));

                            }
                            else
                            {
                                gradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(0xFF, 0x83, 0xDA, 0x64), 0.0));
                                gradientBrush.GradientStops.Add(new GradientStop(Colors.Black, 1.0));
                            }
                            

                        }
                        else
                        {
                            if (gameControl.field[row, col].Getcolor())
                            {
                                gradientBrush.GradientStops.Add(new GradientStop(Colors.DarkCyan, 0.0));
                                gradientBrush.GradientStops.Add(new GradientStop(Colors.Black, 1.0));

                            }
                            else
                            {
                                gradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(0xFF, 0x83, 0xDA, 0x64), 0.0));
                                gradientBrush.GradientStops.Add(new GradientStop(Colors.Black, 1.0));
                            }
                            button.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF0000"));
                            button.Content = "X";

                        }
                    }
                    else
                    {
                        gradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(0xFF, 0xC4, 0xE1, 0xEF), 0.0));
                        gradientBrush.GradientStops.Add(new GradientStop(Colors.Black, 1.0));
                    }

                    

                    button.Background = gradientBrush;

                    button.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC3C3C3"));

                    //button.MouseLeftButtonDown += Button_Click_Left;
                    button.Click += Button_Click_Left;
                    button.MouseRightButtonDown += Button_MouseRightButtonDown; ;





                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);

                    buttonGrid.Children.Add(button);
                }
            }
        }


        private void Hinttop()
        {
            Hinter hinttop = new Hinter(gameControl.field);
            string[] topstring=new string[10];
            string result = "";
            for (int i=0;i<5;i++)
            {
                topstring = hinttop.HintGeterTop(i);
                for (int j = 0; j < 10; j++)
                {
                    if (topstring[j] == "10")
                    {
                        
                         result += topstring[j];
                        result += "    ";
                    }
                    else
                    {
                        
                        result += topstring[j];
                        result += "      ";
                    }
                    
                    

                    
                }
                
                result += "\n";
                
            }
            
            tophint.FontSize = 9.15;
            tophint.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            tophint.Text = result;
        }

        private void Hintleft()
        {
            Hinter hinttop = new Hinter(gameControl.field);
            string[] topstring = new string[10];
            string result = "";
            result += "────────────────";
            result += "\n";
            for (int i = 0; i < 20; i++)
            {
                
                if (i % 2 == 0)
                {
                    topstring = hinttop.HintGeterLeft(i / 2);
                    for (int j = 0; j < 5; j++)
                    {

                        result += "  ";
                        result += topstring[j];
                        result += "  ";
                    }
                    result += "\n";
                }

                else
                {
                    result += "────────────────";
                    result += "\n";
                }
                    

            }
            lefthint.FontSize = 7.48;
            lefthint.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            lefthint.Text = result;
        }



        private void Button_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Button clickedButton = (Button)sender;
            string[] coordinates = clickedButton.Name.Split('_');
            int row = int.Parse(coordinates[1]);
            int col = int.Parse(coordinates[2]);
            //clickedButton.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC80000"));

            if (!gameControl.field[row, col].Answer())
            {
                if (gameControl.field[row, col].Iscolor(false))
                {
                    
                    scoremodule.Score++;
                    


                    RadialGradientBrush gradientBrush = new RadialGradientBrush();
                    gradientBrush.GradientOrigin = new Point(0.5, 0.5);
                    gradientBrush.Center = new Point(0.5, 0.5);
                    gradientBrush.RadiusX = 1.1;
                    gradientBrush.RadiusY = 1.1;



                    gradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(0xFF, 0x83, 0xDA, 0x64), 0.0));
                    gradientBrush.GradientStops.Add(new GradientStop(Colors.Black, 1.0));

                    clickedButton.Background = gradientBrush;
                }
                else
                {
                    scoremodule.Scorebad++;
                    scoremodule.Scoreprogress++;

                    RadialGradientBrush gradientBrush = new RadialGradientBrush();
                    gradientBrush.GradientOrigin = new Point(0.5, 0.5);
                    gradientBrush.Center = new Point(0.5, 0.5);
                    gradientBrush.RadiusX = 1.1;
                    gradientBrush.RadiusY = 1.1;



                    gradientBrush.GradientStops.Add(new GradientStop(Colors.DarkCyan, 0.0));
                    gradientBrush.GradientStops.Add(new GradientStop(Colors.Black, 1.0));

                    clickedButton.Background = gradientBrush;

                    clickedButton.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF0000"));
                    clickedButton.Content = "X";

                }
                scoreupdate();
            }
        }

        private void InitializeField()
        {
            gameControl = new Gra();
            scoremodule =  gameControl.score;
        }
        private void loadfield()
        {
            gameControl = new Gra("continue.txt");
            scoremodule =gameControl.score;
        }
        private void Button_Click_Left(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            string[] coordinates=clickedButton.Name.Split('_');
            int row = int.Parse(coordinates[1]);
            int col = int.Parse(coordinates[2]);
            //clickedButton.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC80000"));

            if (!gameControl.field[row,col].Answer())
            {
                if (gameControl.field[row,col].Iscolor(true)  )
                {
                    scoremodule.Scorecorrect++;
                    scoremodule.Score++;
                    scoremodule.Scoreprogress++;


                    RadialGradientBrush gradientBrush = new RadialGradientBrush();
                    gradientBrush.GradientOrigin = new Point(0.5, 0.5);
                    gradientBrush.Center = new Point(0.5, 0.5);
                    gradientBrush.RadiusX = 1.1;
                    gradientBrush.RadiusY = 1.1;



                    gradientBrush.GradientStops.Add(new GradientStop(Colors.DarkCyan, 0.0));
                    gradientBrush.GradientStops.Add(new GradientStop(Colors.Black, 1.0));

                    clickedButton.Background = gradientBrush;
                }
                else 
                {
                    scoremodule.Scorebad++;

                    RadialGradientBrush gradientBrush = new RadialGradientBrush();
                    gradientBrush.GradientOrigin = new Point(0.5, 0.5);
                    gradientBrush.Center = new Point(0.5, 0.5);
                    gradientBrush.RadiusX = 1.1;
                    gradientBrush.RadiusY = 1.1;



                    gradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(0xFF, 0x83, 0xDA, 0x64), 0.0));
                    gradientBrush.GradientStops.Add(new GradientStop(Colors.Black, 1.0));

                    clickedButton.Background = gradientBrush;

                    clickedButton.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF0000"));
                    clickedButton.Content = "X";

                }
                scoreupdate();
            }
        }

    

        private void Exit_click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow?.Close();
        }

        private void Exit_menu_Click(object sender, RoutedEventArgs e)
        {
            
            Window parentWindow =   Window.GetWindow (this);

            parentWindow.Content = new MainMenu();
            
        }

        private void NewGameButton(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            parentWindow.Content = new Game();
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            gameControl.GameSaver();
        }

        private void LoadGameButtonClick(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            parentWindow.Content = new Game(true);
        }

        private void scoreupdate()
        {
            score.Text = $"Progres\n{((scoremodule.Scoreprogress * 100 )/ scoremodule.Scoretrue)}%\n\nMistakes";

            if(scoremodule.Scorebad==0)
            {
                miss.Text = $"{scoremodule.Scorebad}";
            }
            else
            {
                miss.Foreground = Brushes.Red;
                miss.Text = $"{scoremodule.Scorebad}";
            }
            
        }
        
        private void menu_esc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                if(Buttons.Visibility == Visibility.Hidden)
                Buttons.Visibility = Visibility.Visible;
                else
                    Buttons.Visibility = Visibility.Hidden;
            }
        }
    }
}

