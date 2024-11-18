//using ConsoleApp5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    public class products
    {
        //Id, Name, Price

        public int Id { get; set; }
        public string Name { get; set; } 
        public decimal Price { get; set; }
        public ICollection<baskets> Baskets { get; set; }
    }
}
