using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
            fillingsearch();
            filling();
        }
        private async void fillingsearch()
        {
            Price.Items.Add("Price");
            Price.Items.Add("<100");
            Price.Items.Add("100-500");
            Price.Items.Add("500-1000");
            Price.Items.Add("1000+");

            catg.Items.Add("Categoria");

            Weight.Items.Add("Weight");
            Weight.Items.Add("<200g");
            Weight.Items.Add("0,5kg");
            Weight.Items.Add("1-2kg");
            Weight.Items.Add("2kg+");

            Price.SelectedIndex = 0;
            catg.SelectedIndex = 0;
            Weight.SelectedIndex = 0;

            string connectionString = @"Data Source = USER-PC50; Initial Catalog = CakeHouse; Trusted_Connection=True";
            string catall = "SELECT * FROM Categories";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(catall, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();


                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        object name = reader.GetValue(1);
                        catg.Items.Add(name);
                    }
                    reader.Close();
                }

            }
        }
        public class CakeClass
        {
            public int id1 { get; set; }
            public string name1 { get; set; }
            public string Category1 { get; set; }
            public string picture1 { get; set; }
            public int weight1 { get; set; }
            public string Ingridients1 { get; set; }
            public int count1 { get; set; }
            public int price1 { get; set; }
        }
        public ObservableCollection<CakeClass> Cakes { get; set; }
        private async void filling()
        {
            Cakes = new ObservableCollection<CakeClass>();
            string connectionString = @"Data Source = USER-PC50; Initial Catalog = CakeHouse; Trusted_Connection=True";
            string catall = "SELECT * FROM CATEGORIES";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(catall, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();


                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        object id = reader.GetValue(0);
                        object name = reader.GetValue(1);
                        object category = reader.GetValue(1);
                        object picture = reader.GetValue(1);
                        object weight = reader.GetValue(1);
                        object ingridients = reader.GetValue(1);
                        object count = reader.GetValue(1);
                        object price = reader.GetValue(1);
                        Cakes.Add(new CakeClass() { id1 = Convert.ToInt32(id), name1 = name.ToString(), Category1 = category.ToString(), picture1 = picture.ToString(), weight1 = Convert.ToInt32(weight), Ingridients1 = ingridients.ToString(), count1 = Convert.ToInt32(count), price1 = Convert.ToInt32(price) });

                    }
                    reader.Close();
                }

            }
            
        }
           
        
        int enter = 0;
        private void LogClick(object sender, RoutedEventArgs e)
        {
            if (log.Content == "Log out")
            {
                MessageBoxResult res = MessageBox.Show("You want to log out?", "Warning", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.No)
                    return;
                username.Content = "Log In, please";
                enter = 0;
                log.Content = "Log In";
            }
            else
            {
                Register reg = new Register();
                reg.Owner = this;
                Hide();
                reg.ShowDialog();
                username.Content = Name;
                Name = "Cake_House";
                reg.Close();
                enter = 1;
                log.Content = "Log out";
            }
        }

        private void Levitate(object sender, MouseEventArgs e)
        {
            if (sender.ToString().Contains("About"))
            {
                about.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FDF5D3"));
            }
            else if (sender.ToString().Contains("Our"))
            {
                reviews.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FDF5D3"));
            }
            else if (sender.ToString().Contains("Order"))
            {
                order.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FDF5D3"));
            }
            else if (sender.ToString().Contains("Log"))
            {
                log.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FDF5D3"));
            }
            else
            {
                bracket.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FDF5D3"));
            }
        }

        private void Leave(object sender, MouseEventArgs e)
        {
            if (sender.ToString().Contains("About"))
            {
                about.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E1BD77"));
            }
            else if (sender.ToString().Contains("Our"))
            {
                reviews.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E1BD77"));
            }
            else if (sender.ToString().Contains("Order"))
            {
                order.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E1BD77"));
            }
            else if (sender.ToString().Contains("Log"))
            {
                log.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E1BD77"));
            }
            else
            {
                bracket.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E1BD77"));
            }
        }

        private void click(object sender, KeyEventArgs e)
        {
            if (search.Text == "Search...")
            {
                search.Foreground = Brushes.Black;
                search.Text = "";
            }
        }
    }
}
