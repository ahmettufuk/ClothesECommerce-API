using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.DTOs
{
    public class SaleDetails : IDto
    {
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public short SaleAmount { get; set; }
        public decimal SaledPrice { get; set; }
        public decimal BeforeSaledPrice { get; set; }
        public DateTime SaleFinishDate { get; set; }
        public string Description { get; set; }
    }
}
