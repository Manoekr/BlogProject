using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PostDetailDto:IDto
    {
        public int PostId { get; set; }
        public string? ImagePath { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tag { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int LikeNumber { get; set; }
        public int ViewNumber { get; set; }
        public string CommentNameSurname { get; set; }
        public string CommentText { get; set; }
    }
}
