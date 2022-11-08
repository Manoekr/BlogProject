using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPostService
    {
        IDataResult<List<Post>> GetAll();
        IDataResult<List<Post>> GetAllByCategoryId(int id);
        IDataResult<Post> GetById(int postId);
        IResult Add(Post post);
        IResult Update(Post post);
        IResult Delete(Post post);
        IDataResult<List<PostDetailDto>> GetPostDetails();
    }
}
