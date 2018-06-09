using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string HashedPassword { get; set; }
        public List<Order> UpcomingEvents { get; set; }
        public List<Order> PastEvents { get; set; }


        public void ChangePassword(string pass)
        {
            HashedPassword = null;
            HashedPassword = pass;
        }
        
        public void ChangeName(string name)
        {
            Name = null;
            Name = name;
        }

        public void AddOrder(Order order)  //Добавление заказа в список предстоящих, требует доработки, чтобы два пользователя не могли записаться на одно время 
        {
            if(!UpcomingEvents.Contains(order))
            {
                UpcomingEvents.Add(order);
            }
        }

        public void CancelOrder(Order order)  //Потенциально метод для отмены заказа, но пока нет, та же причина, что и Add, но в целом рабочие
        {
            if (UpcomingEvents.Contains(order))
            {
                UpcomingEvents.Remove(order);
            }
        }

        public void PushOrderToPastEvents(Order order)  //Метод для перевода заказов из статуса предстоящие в прошешие
        {
            if (order.Date<DateTime.Now)
            {
                UpcomingEvents.Remove(order);
                PastEvents.Add(order);
            }
        }
    }
}
