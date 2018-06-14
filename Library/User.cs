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
        public string TelNumber { get; set; }
        public int Discount { get; set; }
        public virtual List<Order> Events { get; set; } = new List<Order>();
        


       

        public void AddOrder(Order order)  //Добавление заказа в список предстоящих, требует доработки, чтобы два пользователя не могли записаться на одно время 
        {
            if (!Events.Contains(order))
            {
                Events.Add(order);
            }
        }

 
        public int GetDiscountValue(Order order)
        {
            int total = Events.Count;
            if (total > 7 && total <= 15) { Discount = 3; }
            if (total > 15 && total <= 30) { Discount = 5; }
            if (total > 30 && total <= 40) { Discount = 10; }
            if (total > 40 && total <= 50) { Discount = 15; }
            if (total > 50) { Discount = 20; }
            return Discount;
        }

        public double PriceWithDiscount(Order order)
        {
            double priceWithDiscount;
            if (Discount >= 3) { priceWithDiscount = (order.Service.Price * (100 - Discount)) / 100; }
            else { priceWithDiscount = order.Service.Price; }
            return priceWithDiscount;
        }

        
    }
}
