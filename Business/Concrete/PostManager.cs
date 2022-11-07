using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PostManager : IPostService
    {
        IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public IResult Add(Post post)
        {
            _postDal.Add(post);
            return new SuccessResult();
        }

        public IResult Delete(Post post)
        {
            _postDal.Delete(post);
            return new SuccessResult();
        }

        public IDataResult<List<Post>> GetAll()
        {
            return new SuccessDataResult<List<Post>>(_postDal.GetAll());
        }

        public IDataResult<List<Post>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Post>>(_postDal.GetAll(p=>p.CategoryId==id));
        }

        public IDataResult<Post> GetById(int postId)
        {
            return new SuccessDataResult<Post>(_postDal.Get(p => p.PostId == postId));
        }

        public IResult Update(Post post)
        {
            _postDal.Update(post);
            return new SuccessResult();
        }
    }
}
