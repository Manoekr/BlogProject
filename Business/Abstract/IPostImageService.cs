using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPostImageService
    {
        IResult Add(List<IFormFile> formFile, PostImage postImage, int postId);
        IResult Delete(PostImage postImage);
        IResult Update(List<IFormFile> formFile, PostImage postImage);
        IDataResult<List<PostImage>> GetAll();
        IDataResult<List<PostImage>> GetByPostId(int postId);
        IDataResult<PostImage> GetByImageId(int imageId);
    }
}
