using Business.Abstract;
using Business.Constants;
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
    public class LikeManager : ILikeService
    {
        ILikeDal _likeDal;

        public LikeManager(ILikeDal likeDal)
        {
            _likeDal = likeDal;
        }

        public IResult Add(Like like)
        {
            _likeDal.Add(like);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Like like)
        {
            _likeDal.Delete(like);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Like>> GetAll()
        {
            return new SuccessDataResult<List<Like>>(_likeDal.GetAll());
        }

        public IDataResult<Like> GetById(int likeId)
        {
            return new SuccessDataResult<Like>(_likeDal.Get(l=>l.LikeId==likeId));
        }

        public IResult Update(Like like)
        {
            _likeDal.Update(like);
            return new SuccessResult(Messages.Updated);
        }
    }
}
