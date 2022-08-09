using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Colour : IEntity
    {
        public int Id { get; set; }
        public string ColourName { get; set; }
    }
}
