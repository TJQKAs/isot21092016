using System;
using System.Collections.Generic;
using System.Collections;
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

namespace isot21092016
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<double> xvar14 = new List<double> { 0.001, 0.1, -1, 1, 4, 6 }; 
        double avar = 1.5;

        public MainWindow()
        {
            InitializeComponent();
           
        }

        public static double var1(double x)
        {
            double part1 = (2 * Math.Pow(x, 3) + 6 * Math.Pow(x, 2) - 8 * x + 4);
            double part2 = (-4 * Math.Pow(x, 3) + 8 * Math.Pow(x, 2) - Math.Pow(x, 5) + 2 * Math.Pow(x, 4));

            if (part1 != 0 && part2 != 0)
            {
                double part3 = part1 / part2;
                return part3;
            }
            else
            {
                double part3 = 0;
                MessageBox.Show("Вероятно предпринята попытка деления на ноль, будет возвращен нулевой результат");
                return part3; 
            }

        }

        public static double var4(double x, double a)
        {
            double part1 = Math.Pow(a, x) * Math.Pow(x, a) + 2 * Math.Pow(a, 2 * x) * Math.Pow(x, a) - 2 * Math.Pow(a, x) * Math.Pow(x, 2 * a) - 4 * Math.Pow(a, 2 * x) * Math.Pow(x, 2 * a);
            double part2 = Math.Log10(a) + Math.Log10(x);
            if (part1 != 0 && part2 != 0)
            {
                double part3 = part1 / part2;
                return part3;
            }
            else
            {
                double part3 = 0;
                MessageBox.Show("Вероятно предпринята попытка деления на ноль, будет возвращен нулевой результат");
                return part3;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double res;
            double result;
            if (tbx1.Text == "" || tbx1.Text == "0")
            {
                    MessageBox.Show("Вероятно введено не числовое значение, 0 или не число");
                    result = 0;
                    tbl1.Text = result.ToString();
            }
            else
            {
                    Double.TryParse(tbx1.Text, out res);
                    result = var1(res);
                    tbl1.Text = result.ToString();
              
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            double res;
            double res1;
            double result;
            Double.TryParse(tbx1.Text, out res1);
            if (res1 > 0)
            {
                if (tbx2.Text == "" || tbx1.Text == "0")
                {
                    MessageBox.Show("Вероятно введено не числовое значение, 0 или не число");
                    result = 0;
                    tbl2.Text = result.ToString();
                }
                else
                {
                    Double.TryParse(tbx1.Text, out res);
                    result = var4(res, res1);
                    tbl2.Text = result.ToString();
                }
            }else
            {
                MessageBox.Show("Вероятно введено не числовое значение, или значение для расчета логарифма меньше или равно 0");
                result = 0;
                tbl2.Text = result.ToString();
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            tbl1.Text = "";
            tbl2.Text = "";
            tbx1.Text = "";
            tbx2.Text = "";
            stpd2.DataContext = "";
            stpd1.DataContext = "";

                //MessageBox.Show(stpd1.Children.Count.ToString());
            while (stpd1.Children.Count != 0)
            {
                int i = 0;
                stpd1.Children.RemoveAt(0);
                i++;
                //MessageBox.Show(stpd1.Children.Count.ToString());
            }
            while (stpd2.Children.Count != 0)
            {
                int i = 0;
                stpd2.Children.RemoveAt(0);
                i++;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            xvar14.ForEach(x=>
            {
                ListBoxItem lbi = new ListBoxItem();
                stpd1.Children.Add(lbi);
                double result = var1(x);
                result = Math.Round(result, 4);
                lbi.Background = Brushes.LightGray ;
                lbi.Foreground = Brushes.DarkViolet;
                //lbi.FontFamily = "Bold";
                lbi.Content = result.ToString();
            });

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            xvar14.ForEach(x =>
            {
                ListBoxItem lbi = new ListBoxItem();
                stpd2.Children.Add(lbi);
                double result = var4(x,avar);
                result = Math.Round(result, 4);
                lbi.Background = Brushes.LightGreen;
                lbi.Foreground = Brushes.DarkSlateGray;
                //lbi.FontFamily = "Bold";
                lbi.Content = result.ToString();
            });
        }
    }
}
