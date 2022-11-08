using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helper.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PostImageManager : IPostImageService
    {
        IPostImageDal _postImageDal;
        IFileHelper _fileHelper;

        public PostImageManager(IPostImageDal postImageDal, IFileHelper fileHelper)
        {
            _postImageDal = postImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(List<IFormFile> formFile, PostImage postImage, int postId)
        {
            IResult result = BusinessRules.Run(CheckIfPostImageLimit(postImage.PostId));
            if (result!=null)
            {
                return result;
            }
            postImage.ImagePath = _fileHelper.Upload(formFile, FilePath.ImagesPath);
            postImage.PostId = postId;
            postImage.Date = DateTime.Now;
            _postImageDal.Add(postImage);
            return new SuccessResult();
        }

        public IResult Delete(PostImage postImage)
        {
            _fileHelper.Delete(FilePath.ImagesPath + postImage.ImagePath);
            _postImageDal.Delete(postImage);
            return new SuccessResult();
        }

        public IDataResult<List<PostImage>> GetAll()
        {
            return new SuccessDataResult<List<PostImage>>(_postImageDal.GetAll());
        }

        public IDataResult<PostImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<PostImage>(_postImageDal.Get(p=>p.PostImageId==imageId));
        }

        public IDataResult<List<PostImage>> GetByPostId(int postId)
        {
            return new SuccessDataResult<List<PostImage>>(_postImageDal.GetAll(p => p.PostId == postId));
        }

        public IResult Update(List<IFormFile> formFile, PostImage postImage)
        {
            postImage.ImagePath = _fileHelper.Update(formFile, FilePath.ImagesPath + postImage.ImagePath, FilePath.ImagesPath);
            _postImageDal.Update(postImage);
            return new SuccessResult();
        }
        private IResult CheckIfPostImageLimit(int postId)
        {
            var result = _postImageDal.GetAll(p => p.PostId == postId).Count;
            if (result>=1)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
