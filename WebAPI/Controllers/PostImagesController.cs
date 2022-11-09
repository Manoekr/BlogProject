using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostImagesController : ControllerBase
    {
        IPostImageService _postImageService;

        public PostImagesController(IPostImageService postImageService)
        {
            _postImageService = postImageService;
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm] List<IFormFile> formFile, [FromForm] int postId)
        {
            var postImage = new PostImage() { PostId = postId };
            var result = _postImageService.Add(formFile,postImage,postId);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(PostImage postImage)
        {
            var postDeleteImage = _postImageService.GetByImageId(postImage.PostImageId).Data;
            var result = _postImageService.Delete(postDeleteImage);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] List<IFormFile> formFile, [FromForm] PostImage postImage)
        {
            var result = _postImageService.Update(formFile,postImage);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _postImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetByPostId(int postId)
        {
            var result = _postImageService.GetByPostId(postId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyimageid")]
        public IActionResult GetByImageId(int imageId)
        {
            var result = _postImageService.GetByImageId(imageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
