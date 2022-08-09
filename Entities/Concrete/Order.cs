using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public ICollection<Product> Products { get; set; }
        public User User { get; set; }
    }
}
