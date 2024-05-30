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

namespace Autorization
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

        private void autor_Click(object sender, RoutedEventArgs e)
        {

            int userId = ViewModel.CheckUser(ViewModel.GetUsers(), log_tb.Text, pass_tb.Text);

            if (userId != 0)
            {
                UserSingleton.User = ViewModel.GetUser(ViewModel.GetUsers(), userId);
                UserSingleton.isAuth = true;

                Major profile = new Major();
                profile.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Нет такого пользователя 😐");
            }
        }

        private void registr_Click(object sender, RoutedEventArgs e)
        {
            Registr registr = new Registr();
            registr.Show();
            Close();
        }
    }
}
