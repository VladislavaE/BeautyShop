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
using Library;

namespace WorkshopOfBeauty
{
    /// <summary>
    /// Логика взаимодействия для RegistrationForm.xaml
    /// </summary>
    public partial class RegistrationForm : Window
    {
        public UsersDatabaseRepository Users;
        public RegistrationForm(UsersDatabaseRepository users)
        {
            Users = users;
            InitializeComponent();
        }

        private void ButtonRegisterInForm_Click(object sender, RoutedEventArgs e)
        {
     
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ButtonOkRegister_Click(object sender, RoutedEventArgs e)
        {
            Users.RegisterUser(textBoxName.Text, textBoxEmail.Text, passwordBoxPassword.Password);
            DialogResult = true;
            string passwordNew = passwordBoxPassword.Password;

            if (String.IsNullOrEmpty(passwordNew))
            {
                MessageBox.Show("Incorrect password", "Error");
            }
         
        }
    }
}
