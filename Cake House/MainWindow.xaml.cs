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

namespace Cake_House
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogClick(object sender, RoutedEventArgs e)
        {
            Register reg = new Register();
            Hide();
            reg.ShowDialog();
        }

        private void Levitate(object sender, MouseEventArgs e)
        {
            if (sender.ToString().Contains("About"))
            {
                
            }
            else if (sender.ToString().Contains("Our"))
            {

            }
            else if (sender.ToString().Contains("Order"))
            {

            }
            else if (sender.ToString().Contains("Log"))
            {

            }
            else
            {

            }
        }

        private void Leave(object sender, MouseEventArgs e)
        {
            if (sender.ToString().Contains("About"))
            {

            }
            else if (sender.ToString().Contains("Our"))
            {

            }
            else if (sender.ToString().Contains("Order"))
            {

            }
            else if (sender.ToString().Contains("Log"))
            {

            }
            else
            {

            }
        }
    }
}
