using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rysowaniess4
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
        void RysujLinie(int x1,int y1,int x2,int y2, int grubosc,Brush pedel)
        {
            Line myLine = new Line();
            myLine.Stroke = pedel;
            myLine.X1 = x1;
            myLine.X2 = x2;
            myLine.Y1 = y1;
            myLine.Y2 = y2;
            myLine.StrokeThickness = grubosc;
            cvRysunek.Children.Add(myLine);
        }
        void rysujkrzyz(int xsr, int ysr, int ramie, int gr, Brush pedel)
        {
            RysujLinie(xsr, ysr, xsr + (ramie), xsr, gr, pedel);
            RysujLinie(xsr, ysr, xsr - (ramie), xsr, gr, pedel);
            RysujLinie(xsr, ysr, xsr , xsr - (ramie), gr, pedel);
            RysujLinie(xsr, ysr, xsr, xsr + (ramie), gr, pedel);
        }
        void rysujDrzewo(int h, int w, int xsr, int ysr)
        {
            Ellipse elips = new Ellipse();
            elips.Stroke = Brushes.Green;
            elips.Width = h;
            elips.Height = w;
            elips.Fill = Brushes.Green;  
            cvRysunek.Children.Add(elips);
           Canvas.SetLeft(elips, xsr);
           Canvas.SetTop(elips, ysr);
            RysujLinie(h / 2 + xsr,  w + ysr, h / 2+ xsr, w + ysr + 60, 8, Brushes.Chocolate);
        }
        void rysujlas(int g)
        {
            Random random = new Random();
           
            for(int i = 0; i < g; i++)
            {
                double result = random.NextDouble() * (1.2 - 0.8) + 0.8;
                rysujDrzewo(Convert.ToInt32(100*result), Convert.ToInt32(100 * result), 50*i, 100);
            }
            
        }
        private void btnRysuj_Click(object sender, RoutedEventArgs e)
        {

            //Line myLine = new Line();
            //myLine.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            //myLine.X1 = 1;
            //myLine.X2 = 50;
            //myLine.Y1 = 1;
            //myLine.Y2 = 50;
            //myLine.StrokeThickness = 2;
            //cvRysunek.Children.Add(myLine);
            // RysujLinie(0, 149, 299, 149, 2, Brushes.LightSteelBlue);
            // RysujLinie(149, 149, 149, 299, 2, Brushes.LightSteelBlue);


           // rysujkrzyz(149, 149, 50, 4, Brushes.LightSteelBlue);
            //rysujDrzewo(100,100,149,149);
            rysujlas(6);
        }
    }
}