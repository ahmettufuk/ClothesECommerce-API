using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Comment : IEntity
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public string CommentDescription { get; set; }
    }
}
