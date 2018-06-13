﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public interface IUsersRepository
    {
        void RegisterUser(string name, string login, string password);
        User LoginUser(string login, string password);
        void AddVisitToUser(Order order, User user);
        void RemoveVisitFromUser(Order order, User user);
    }
}
