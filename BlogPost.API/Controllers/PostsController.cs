using BlogPost.Application.UseCases.Post.Commands;
using BlogPost.Application.UseCases.Posts.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPost.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreatePost(CreatePostCommand command)
        {
            await _mediator.Send(command);

            return Ok("yaratildi");
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetPosts()
        {
            var result =  await _mediator.Send(new GetPostsQuery());

            return Ok(result);
        }
    }
}
