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
    /// Логика взаимодействия для PrivateOffice.xaml
    /// </summary>
    public partial class PrivateOffice : Window
    {
        User LoggedInUser;
        UsersDatabaseRepository Users;

        public PrivateOffice(User loggedInUser, UsersDatabaseRepository users)
        {
            LoggedInUser = loggedInUser;
            Users = users;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
