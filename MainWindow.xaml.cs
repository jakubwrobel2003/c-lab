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
            try { 
            cvRysunek.Children.Clear();
             int ilosclini = Convert.ToInt32(txtLiczbaLinii.Text);

            Random rand = new Random();
            for (int i = 0; i < ilosclini; i++)
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
            cvCzlowiek.Children.Clear(); // Czyścimy Canvas przed ponownym rysowaniem

            int srodekX = 200;  // Środek postaci w poziomie
            int glowaY = 50;    // Pozycja głowy w pionie
            int tulowY = glowaY + 50; // Pozycja tułowia
            int tulowSzerokosc = 80;  // Szerokość tułowia
            int tulowWysokosc = 120;  // Wysokość tułowia

            // Głowa
            if (chkGlowa.IsChecked == true)
            {
                Ellipse glowa = new Ellipse { Width = 50, Height = 50, Stroke = Brushes.Black, StrokeThickness = 2 };
                cvCzlowiek.Children.Add(glowa);
                Canvas.SetLeft(glowa, srodekX - 25);
                Canvas.SetTop(glowa, glowaY);
            }

            // Tułów (Brzuch)
            if (chkTulow.IsChecked == true)
            {
                Ellipse tulow = new Ellipse
                {
                    Width = tulowSzerokosc,
                    Height = tulowWysokosc,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };
                cvCzlowiek.Children.Add(tulow);
                Canvas.SetLeft(tulow, srodekX - (tulowSzerokosc / 2));
                Canvas.SetTop(tulow, tulowY);
            }

            // Ręce uniesione w górę pod kątem
            if (chkRece.IsChecked == true)
            {
                int rekaStartX = srodekX - (tulowSzerokosc / 2); // Start ramion na krawędzi tułowia
                int rekaEndX_Left = rekaStartX - 50;  // Lewa ręka pod kątem
                int rekaEndX_Right = srodekX + (tulowSzerokosc / 2) + 50; // Prawa ręka pod kątem
                int rekaStartY = tulowY + (tulowWysokosc / 4); // Poziom ramion
                int rekaEndY = rekaStartY - 60; // Uniesienie rąk w górę

                RysujLinie(cvCzlowiek, rekaStartX, rekaStartY, rekaEndX_Left, rekaEndY, Brushes.Black, 3); // Lewa ręka
                RysujLinie(cvCzlowiek, srodekX + (tulowSzerokosc / 2), rekaStartY, rekaEndX_Right, rekaEndY, Brushes.Black, 3); // Prawa ręka
            }

            // Nogi rozstawione
            if (chkNogi.IsChecked == true)
            {
                int nogiStartY = tulowY + tulowWysokosc;  // Punkt startowy nóg
                int nogiEndY = nogiStartY + 50; // Końcowy punkt nóg
                int nogiRozstaw = 20; // Rozstaw nóg

                RysujLinie(cvCzlowiek, srodekX, nogiStartY, srodekX - nogiRozstaw, nogiEndY, Brushes.Black, 3); // Lewa noga
                RysujLinie(cvCzlowiek, srodekX, nogiStartY, srodekX + nogiRozstaw, nogiEndY, Brushes.Black, 3); // Prawa noga
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

        private void zamalujkulko(object sender, RoutedEventArgs e)
        {
            Ellipse elipsa = new Ellipse
            {
                Width = 100,  // Szerokość elipsy
                Height = 100, // Wysokość elipsy
                Fill = new SolidColorBrush(Colors.Red), // Kolor wypełnienia
                Stroke = new SolidColorBrush(Colors.Black), // Kolor obramowania
                StrokeThickness = 2 // Grubość obramowania
            };

            // Ustawienie pozycji elipsy w kontrolce Canvas (jeśli istnieje)
            Canvas.SetLeft(elipsa, 50);
            Canvas.SetTop(elipsa, 50);

            // Dodanie elipsy do kontenera (np. Canvas)
           
                cvRys.Children.Add(elipsa);
           
           
        }
    }
}
