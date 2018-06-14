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
    /// Логика взаимодействия для Confirmation.xaml
    /// </summary>
    public partial class Confirmation : Window
    {
        IUsersRepository Users=UsersDatabaseRepository.ReadFromDatabase();
        User LoggedInUser;
        Order ChosenOrder;
        public Confirmation(IUsersRepository users, User loggedInUser, Order order)
        {
            Users = users;
            LoggedInUser = loggedInUser;
            ChosenOrder = order;
            textBoxService.Text = ChosenOrder.Service.Name;
            textBoxMaster.Text = ChosenOrder.Master.Name;
            textBoxDate.Text = ChosenOrder.Date.ToString();
            textBoxPrice.Text = ChosenOrder.Price.ToString();
            InitializeComponent();
        
        }
        
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Order AddedOrder = ChosenOrder;
            Users.AddVisitToUser(AddedOrder, LoggedInUser);
            

            MessageBox.Show("Заказ успешно оформлен!");
        }
    }
}
