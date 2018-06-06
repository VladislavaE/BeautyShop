using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class User
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string HashedPassword { get; set; }

        string s = Console.ReadLine();
        
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
    }
}
