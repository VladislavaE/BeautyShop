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
        IUsersRepository users = UsersDatabaseRepository.ReadFromDatabase();
        IServiceAndMastersRepository services = ServiceAndMastersRepository.ReadServicesFromDatabase();
        IServiceAndMastersRepository orders = ServiceAndMastersRepository.ReadOrdersFromDatabase();
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void ButtonlLogin_Click(object sender, RoutedEventArgs e)
        {
            
            User us = users.LoginUser(textBoxEmail.Text, passwordBoxPassword.Password);
            if (us == null) { var error = new ErrorWindow().ShowDialog(); }
            else {
                new PrivateOffice(services,users, us,orders).ShowDialog();
            }
            //string login = textBoxEmail.Text;
            //if (!login.Logincheck(login)) we can make a method to check login if it is written correctly according to the rules!
            //{
            //    MessageBox.Show("Email not valid", "Error");
            //    return;
            //}

            //string password = passwordBoxPassword.Password;
            //string errorText = PassCheck.PasswordCheck(((App)Application.Current).RepositorySchedule.Users, login, password);

            //if (!String.IsNullOrEmpty(errorText))
            //{
            //    MessageBox.Show(errorText, "Error");
            //    return;
            //}
            
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            var registration = new RegistrationForm(users);
            registration.ShowDialog();

        }

        
       

        
    }
}
