using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        ILikeService _likeService;

        public LikesController(ILikeService likeService)
        {
            _likeService = likeService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _likeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Like like) 
        {
            var result = _likeService.Add(like);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Like like)
        {
            var result = _likeService.Update(like);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Like like)
        {
            var likeDelete = _likeService.GetById(like.PostId).Data;
            var result = _likeService.Delete(likeDelete);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
