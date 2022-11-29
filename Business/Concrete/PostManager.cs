using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        [ValidationAspect(typeof(PostValidator))]
        [SecuredOperation("post.list,post.add,admin")]
        [CacheRemoveAspect("IPostService.Get")]
        public IResult Add(Post post)
        {
            _postDal.Add(post);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Post post)
        {
            _postDal.Delete(post);
            return new SuccessResult(Messages.Deleted);
        }
        [CacheAspect]
        public IDataResult<List<Post>> GetAll()
        {
            return new SuccessDataResult<List<Post>>(_postDal.GetAll());
        }

        public IDataResult<List<Post>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Post>>(_postDal.GetAll(p=>p.CategoryId==id));
        }
        [CacheAspect]
        public IDataResult<Post> GetById(int postId)
        {
            return new SuccessDataResult<Post>(_postDal.Get(p => p.PostId == postId));
        }

        public IDataResult<List<PostDetailDto>> GetPostDetails()
        {
            return new SuccessDataResult<List<PostDetailDto>>(_postDal.GetPostDetails());
        }
        [CacheRemoveAspect("IPostService.Get")]
        public IResult Update(Post post)
        {
            _postDal.Update(post);
            return new SuccessResult(Messages.Updated);
        }
    }
}
