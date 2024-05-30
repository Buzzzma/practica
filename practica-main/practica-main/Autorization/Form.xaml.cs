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
    /// Логика взаимодействия для Form.xaml
    /// </summary>
    public partial class Form : Window
    {
        public Form()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> marks = new List<string>();
            foreach (Cars mark in ViewModel.GetCars())
            {
                marks.Add(mark.mark);
            }
            marks_cb.ItemsSource = marks;
        }

        private void Buy_Button(object sender, RoutedEventArgs e)
        {
            foreach (var car in ViewModel.GetCars())
            {
                if (car.mark == (string)marks_cb.SelectedItem)
                {
                    if (car.count > Convert.ToInt32(count_cb.Text))
                    {
                        ViewModel.WriteClient($"{username_tb.Text},{usersurname_tb.Text},{marks_cb.SelectedValue},{count_cb.Text}");
                        ViewModel.ReplaceInFile(".\\..\\..\\cars.txt", 
                            $"{car.mark},{car.model},{car.date},{car.count}", 
                            $"{car.mark},{car.model},{car.date},{car.count - Convert.ToInt32(count_cb.Text)}");

                        Major profile = new Major();
                        profile.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка");
                    }
                }
            }
        }
    }
}
