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
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        public Registr()
        {
            InitializeComponent();
        }

        private void auth_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void registr_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.WriteUser($"{log_tb.Text},{pass_tb.Text},User");

            UserSingleton.isAuth = true;
            UserSingleton.User = new UserModel
            {
                Id = 1488,
                login = log_tb.Text,
                password = pass_tb.Text
            };

            Major profile = new Major();
            profile.Show();
            Close();
        }
    }
}
