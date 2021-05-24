using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class UsersModel
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public string city { get; set; }
        public string announcement { get; set; }
        public string password { get; set; }
    }
}
