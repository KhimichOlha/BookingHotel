using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string  Phone {  get; set; }
        public int LoyaltyPoints {  get; set; }
        public string UserId { get; set; }

    }
}
