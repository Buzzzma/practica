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
using System.Windows.Shapes;

namespace Autorization
{
    /// <summary>
    /// Логика взаимодействия для Major.xaml
    /// </summary>
    public partial class Major : Window
    {
        public Major()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listview.ItemsSource = ViewModel.GetCars();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            listview.Visibility = Visibility.Hidden;
            listviewuser.Visibility = Visibility.Visible;
            listviewuser.ItemsSource = ViewModel.GetClients();
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            listviewuser.Visibility = Visibility.Hidden;
            listview.Visibility = Visibility.Visible;
            listview.ItemsSource = ViewModel.GetCars();
        }

        private void Form_Click(object sender, RoutedEventArgs e)
        {
            Form form= new Form();
            form.Show();
            Close();
        }
    }
}
