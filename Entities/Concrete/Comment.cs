using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comment:IEntity
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string CommentNameSurname { get; set; }
        public string CommentText { get; set; }
        
    }
}
