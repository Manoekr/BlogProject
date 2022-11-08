using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPostDal : EfEntityRepositoryBase<Post, BlogdbContext>, IPostDal
    {
        public List<PostDetailDto> GetPostDetails()
        {
            using (BlogdbContext context = new BlogdbContext())
            {
                var result = from post in context.Posts
                             join category in context.Categories on post.CategoryId equals category.CategoryId
                             join comment in context.Comments on post.PostId equals comment.PostId
                             select new PostDetailDto
                             {
                                 PostId = post.PostId,
                                 CategoryName = category.CategoryName,
                                 Title = post.Title,
                                 Content = post.Content,
                                 Tag = post.Tag,
                                 CreateDate = post.CreateDate,
                                 UpdateDate = post.UpdateDate,
                                 CommentNameSurname = comment.CommentNameSurname,
                                 CommentText = comment.CommentText,
                             };
                return result.ToList();
            }
        }
    }
}
