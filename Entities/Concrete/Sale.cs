using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Sale : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ProductId { get; set; }
        public short SaleAmount { get; set; }
        public DateTime SaleStartDate { get; set; }
        public DateTime SaleFinishDate { get; set; }
        public string Description { get; set; }

    }
}
