using BlogPost.Application.Abstractions;
using BlogPost.Application.UseCases.Posts.Queries;
using BlogPost.Application.UseCases.ResponseModels;
using BlogPost.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.UseCases.Posts.Handlers
{
    //GetPostsQueryResponse ishlatme turelik
    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, List<PostDTO>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetPostsQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<PostDTO>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            //var posts = await _applicationDbContext.Posts.OfType<UseTPC>().ToArrayAsync(cancellationToken);
            var posts = await _applicationDbContext.Posts.Select(x => new PostDTO
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
            }).ToListAsync(cancellationToken);

            return posts;


        }
    }
}
