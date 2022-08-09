using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColourId { get; set; }
        public int SizeId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public int UnitInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
    }
}
