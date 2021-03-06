﻿using System;
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
    /// Логика взаимодействия для MyVisits.xaml
    /// </summary>
    public partial class MyVisits : Window
    {
        IUsersRepository Users;
        User LoggedUser;
        public MyVisits(IUsersRepository users, User loggedUser)
        {
            Users = users;
            LoggedUser = loggedUser;
            InitializeComponent();
            dataGridMyVisits.ItemsSource = LoggedUser.Events;
        }
    }
}
