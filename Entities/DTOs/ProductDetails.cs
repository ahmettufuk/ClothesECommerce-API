using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.DTOs
{
    public class ProductDetails : IDto
    {
        public int  Id { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string ColourName { get; set; }
        public string SizeName { get; set; }
        public string ProductName { get; set; }
        public int UnitInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }

        
    }
}
