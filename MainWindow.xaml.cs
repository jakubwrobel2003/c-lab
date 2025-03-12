using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 📌 GRUPA A - RYSOWANIE LOSOWYCH LINII
        private void btnRysuj_Click(object sender, RoutedEventArgs e)
        {
            cvRysunek.Children.Clear();
            if (!int.TryParse(txtLiczbaLinii.Text, out int liczbaLinii) || liczbaLinii <= 0)
            {
                MessageBox.Show("Podaj poprawną liczbę linii!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Random rand = new Random();
            for (int i = 0; i < liczbaLinii; i++)
            {
                Line linia = new Line
                {
                    X1 = rand.Next(0, (int)cvRysunek.Width),
                    Y1 = rand.Next(0, (int)cvRysunek.Height),
                    X2 = rand.Next(0, (int)cvRysunek.Width),
                    Y2 = rand.Next(0, (int)cvRysunek.Height),
                    Stroke = Brushes.Red,
                    StrokeThickness = 2
                };
                cvRysunek.Children.Add(linia);
            }
        }

        // 📌 GRUPA B - RYSOWANIE PŁOTU
        private void btnNarysujPlot_Click(object sender, RoutedEventArgs e)
        {
            cvPlot.Children.Clear();

            // Poziome belki
            RysujLinie(cvPlot, 10, 50, 590, 50, Brushes.Black, 5);
            RysujLinie(cvPlot, 10, 200, 590, 200, Brushes.Black, 5);

            // Pionowe sztachety co 20px
            for (int i = 10; i <= 590; i += 20)
            {
                RysujLinie(cvPlot, i, 50, i, 200, Brushes.Black, 3);
            }
        }

        // 📌 GRUPA C - RYSOWANIE CZŁOWIEKA
        private void RysujCzlowieka(object sender, RoutedEventArgs e)
        {
            cvCzlowiek.Children.Clear();

            if (chkGlowa.IsChecked == true)
            {
                Ellipse glowa = new Ellipse { Width = 50, Height = 50, Stroke = Brushes.Black, StrokeThickness = 2 };
                cvCzlowiek.Children.Add(glowa);
                Canvas.SetLeft(glowa, 275);
                Canvas.SetTop(glowa, 20);
            }

            if (chkTulow.IsChecked == true)
            {
                RysujLinie(cvCzlowiek, 300, 70, 300, 170, Brushes.Black, 3);
            }

            if (chkRece.IsChecked == true)
            {
                RysujLinie(cvCzlowiek, 250, 100, 350, 100, Brushes.Black, 3);
            }

            if (chkNogi.IsChecked == true)
            {
                RysujLinie(cvCzlowiek, 300, 170, 270, 230, Brushes.Black, 3);
                RysujLinie(cvCzlowiek, 300, 170, 330, 230, Brushes.Black, 3);
            }
        }

        // 📌 POMOCNICZA METODA DO RYSOWANIA LINII
        private void RysujLinie(Canvas canvas, int x1, int y1, int x2, int y2, Brush kolor, int grubosc)
        {
            Line linia = new Line
            {
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2,
                Stroke = kolor,
                StrokeThickness = grubosc
            };
            canvas.Children.Add(linia);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double waga = Convert.ToDouble(txtwaga.Text);
                double wzrost = Convert.ToDouble(txtWzrost.Text);

                if (waga > 0 && wzrost > 0)
                {
                    double bmi = waga / (wzrost * wzrost);
                    MessageBox.Show($"BMI: {bmi:F2}");
                }
                else
                {
                    MessageBox.Show("Wprowadzono błędne dane. Waga i wzrost muszą być liczbami większymi od 0.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Błąd! Wprowadź poprawne liczby zamiast liter.");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Wprowadzone wartości są za duże lub za małe.");
            }
            catch (Exception ex) // Ogólny wyjątek na inne błędy
            {
                MessageBox.Show($"Wystąpił nieoczekiwany błąd: {ex.Message}");
            }
        }
        private void btnlinia_click(object sender, RoutedEventArgs e)
        {
            RysujLinie(10, 10, 100, 100, 2, Brushes.Red);
        }


        void RysujLinie(int x1, int y1, int x2, int y2, int grubosc, Brush pedel)
        {
            Line myLine = new Line();
            myLine.Stroke = pedel;
            myLine.X1 = x1;
            myLine.X2 = x2;
            myLine.Y1 = y1;
            myLine.Y2 = y2;
            myLine.StrokeThickness = grubosc;
            cvRysunke.Children.Add(myLine);
        }

        void RysujProstokat(int x, int y, int szerokosc, int wysokosc, int grubosc, Brush pedzel, Brush wypelnienie = null)
        {
            Rectangle prostokat = new Rectangle
            {
                Width = szerokosc,
                Height = wysokosc,
                Stroke = pedzel, // Obrys prostokąta
                StrokeThickness = grubosc,
                Fill = wypelnienie ?? Brushes.Transparent // Opcjonalne wypełnienie
            };

            // Ustawienie pozycji na Canvas
            Canvas.SetLeft(prostokat, x);
            Canvas.SetTop(prostokat, y);

            cvRysunke.Children.Add(prostokat);
        }

        void RysujElipse(int x, int y, int szerokosc, int wysokosc, int grubosc, Brush pedzel, Brush wypelnienie = null)
        {
            Ellipse elipsa = new Ellipse
            {
                Width = szerokosc,
                Height = wysokosc,
                Stroke = pedzel, // Kolor obramowania
                StrokeThickness = grubosc,
                Fill = wypelnienie ?? Brushes.Transparent // Opcjonalne wypełnienie
            };

            // Ustawienie pozycji na Canvas
            Canvas.SetLeft(elipsa, x);
            Canvas.SetTop(elipsa, y);

            cvRysunke.Children.Add(elipsa);
        }


        private void Rysuj(object sender, RoutedEventArgs e)
        {
            try
            {
                int dlugosc = Convert.ToInt32(txtDlugosc.Text);
                int szeroksc = Convert.ToInt32(txtSzerokosc.Text);
                int polorzeniex = Convert.ToInt32(txtPolorzenieX.Text);
                int polorzeniey = Convert.ToInt32(txtPolorzenieY.Text);

                if (radioProstokąt.IsChecked == true)
                {
                    RysujProstokat(polorzeniex, polorzeniey, szeroksc, dlugosc, 3, Brushes.Black);
                }
                else if (radioelipsa.IsChecked == true)
                {
                    RysujElipse(polorzeniex, polorzeniey, szeroksc, dlugosc, 3, Brushes.Blue);
                }
                else
                {
                    MessageBox.Show("Wprowadzono błędne dane. Waga i wzrost muszą być liczbami większymi od 0.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Błąd! Wprowadź poprawne liczby zamiast liter.");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Wprowadzone wartości są za duże lub za małe.");
            }
            catch (Exception ex) // Ogólny wyjątek na inne błędy
            {
                MessageBox.Show($"Wystąpił nieoczekiwany błąd: {ex.Message}");
            }
        }

        private void RysujElipse(object sender, RoutedEventArgs e)
        {
            void RysujElipse(int x, int y, int szerokosc, int wysokosc, int grubosc, Brush pedzel, Brush wypelnienie = null)
            {
                Ellipse elipsa = new Ellipse
                {
                    Width = szerokosc,
                    Height = wysokosc,
                    Stroke = pedzel, // Kolor obramowania
                    StrokeThickness = grubosc,
                    Fill = wypelnienie ?? Brushes.Transparent // Opcjonalne wypełnienie
                };

                // Ustawienie pozycji na Canvas
                Canvas.SetLeft(elipsa, x);
                Canvas.SetTop(elipsa, y);

                cvRysunke.Children.Add(elipsa);
            }
        }

        private void RysujTANK(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i < 5; i++)
            {

                RysujElipse(50 * i, 300, 50, 50, 2, Brushes.Black);

            }
            RysujProstokat(50, 250, 200, 50, 2, Brushes.Black);
            RysujProstokat(50 * 5, 275, 275, 10, 2, Brushes.Black);

        }

    }
}
