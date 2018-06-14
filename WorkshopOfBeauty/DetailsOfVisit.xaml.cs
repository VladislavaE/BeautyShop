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
using System.Data.Entity;
using Library;

namespace WorkshopOfBeauty
{
    /// <summary>
    /// Логика взаимодействия для DetailsOfVisit.xaml
    /// </summary>
    public partial class DetailsOfVisit : Window
    {
        IServiceAndMastersRepository Services;
        IUsersRepository Users;
        IServiceAndMastersRepository Orders;
        User LoggedUser;
        
        public DetailsOfVisit(IServiceAndMastersRepository services,  User loggedUser, IUsersRepository users, IServiceAndMastersRepository orders)
        {
            Orders = orders;
            Users = users;
            LoggedUser = loggedUser;
            Services = services;
            InitializeComponent();
            comboBoxProcedure.ItemsSource = Services.AllServices.ToList();
        }


        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            Order selectedOrder = new Order() { Service = comboBoxProcedure.SelectedItem as Service, Master = comboBoxMaster.SelectedItem as Master, Date = DateTime.Parse(textBoxDate.Text) };
            //new Confirmation(Users, LoggedUser, selectedOrder).ShowDialog();
            Users.AddVisitToUser(selectedOrder, LoggedUser);
        }

        private void comboBoxProcedure_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Service service = comboBoxProcedure.SelectedItem as Service;
            comboBoxMaster.ItemsSource = service.Masters;
            
        }

        private void comboBoxMaster_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Master master = comboBoxMaster.SelectedItem as Master;
            DateTime selectedDate = DateTime.Parse(textBoxDate.Text);
            
            comboBoxTime.ItemsSource = master.AvailableTime(selectedDate);
            comboBoxTime.SelectedIndex = 0;
        }
        
        
    }
}
