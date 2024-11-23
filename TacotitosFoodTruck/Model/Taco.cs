using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacotitosFoodTruck.Models
{
    public class Taco
    {
        public int TacoId { get; set; }
        public string Name { get; set; }
        public decimal TotalPrice { get; set; }
        public int? SauceId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
