using System;
using System.Data;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach(UIElement els in Main.Children)
            {
                if(els is Button)
                {
                    ((Button)els).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Str = (string)((Button)e.OriginalSource).Content;
            double res = 0;
            if (Str == "C")
            {
                Operations.Text = "";
                Resultat.Text = "";
                Str = "";
            }
            else if (Str == "CE")
            {
                res = 0;
                Resultat.Text = "";
            }
            else if (Str == "=") {
                string ds = new DataTable().Compute(Operations.Text, null).ToString();
                res = Convert.ToDouble(ds);
                Resultat.Text = res.ToString();
            }
            else if(Str == "←")
            {
                Operations.Text = Operations.Text.Substring(0, Operations.Text.Length - 1);
            }
            else
            {
                Operations.Text += Str;
            }
            
        }
    }
}
