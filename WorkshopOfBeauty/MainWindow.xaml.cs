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
using Library;

namespace WorkshopOfBeauty
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UsersDatabaseRepository users = UsersDatabaseRepository.testRepo();
       

        public MainWindow()
        {
            TestIt.testMain();
            //InitializeComponent();
        }

        

        private void ButtonlLogin_Click(object sender, RoutedEventArgs e)
        {
            User us = users.LoginUser(textBoxEmail.Text, passwordBoxPassword.Password);
            if (us == null)
            {
                var error = new ErrorWindow().ShowDialog();
            }
            else
            { new PrivateOffice(us, users).ShowDialog(); }
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            var registration = new RegistrationForm(users);
            registration.ShowDialog();
        }

        

        private void ButtonWithoutRegister_Click(object sender, RoutedEventArgs e)
        {
            var withoutregistration = new DetailsOfVisit();
            withoutregistration.ShowDialog();
        }
    }
}
