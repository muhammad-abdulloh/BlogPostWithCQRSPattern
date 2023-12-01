using BlogPost.Application.UseCases.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.UseCases.Posts.Queries
{
    // GetPostsQueryResponse shuni orniga / List<PostDTO> bervora qoldik
    public class GetPostsQuery : IRequest<List<PostDTO>>
    {
        // query logikalar yozishimiz mumkin misol uchun paginationlar shunga o'xshash
    }
}
