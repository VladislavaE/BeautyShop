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
        IServiceAndMastersRepository Services;
        User LoggedInUser;
        IUsersRepository Users;
        IServiceAndMastersRepository Orders;
        public PrivateOffice(IServiceAndMastersRepository services, IUsersRepository users, User loggedUser, IServiceAndMastersRepository orders)
        {
            Orders = orders;
            LoggedInUser = loggedUser;
            Users = users;
            Services = services;
            InitializeComponent();
        }


        

        private void Button_MakeVisit_Click(object sender, RoutedEventArgs e)
        {
            var MakeOrder = new DetailsOfVisit(Services, LoggedInUser, Users, Orders);
            MakeOrder.ShowDialog();
        }

        private void Button_MyVisits_Click(object sender, RoutedEventArgs e)
        {
            var visits = new MyVisits(Users,LoggedInUser);
            visits.ShowDialog();
        }

        private void Button_Discounts_Click(object sender, RoutedEventArgs e)
        {
            var discounts = new Discounts();
            discounts.ShowDialog();
        }

      

     
    }
}
