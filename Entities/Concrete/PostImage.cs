using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PostImage:IEntity
    {
        public int PostImageId { get; set; }
        public int PostId { get; set; }
        public string? ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
