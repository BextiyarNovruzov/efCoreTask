using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    public class baskets
    {
        //Id, UserId, ProductId
        public int Id { get; set; }
        public string Name { get; set; } 
        public int ProductId { get; set; }
        public ICollection<products> Products { get; set; }
    }
}
