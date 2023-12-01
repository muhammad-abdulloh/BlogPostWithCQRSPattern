using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.UseCases.Post.Commands
{
    public class CreatePostCommand : IRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
