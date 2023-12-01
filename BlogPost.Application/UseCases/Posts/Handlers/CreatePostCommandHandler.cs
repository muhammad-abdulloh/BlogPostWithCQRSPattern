using BlogPost.Application.Abstractions;
using BlogPost.Application.Notifications;
using BlogPost.Application.UseCases.Post.Commands;
using MediatR;


namespace BlogPost.Application.UseCases.Post.Handlers
{
    public class CreatePostCommandHandler : AsyncRequestHandler<CreatePostCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;

        public CreatePostCommandHandler(IApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        protected override async Task Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.Post()
            {
                Title = request.Title,
                Content = request.Content
            };

            var entry = await _context.Posts.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new PostCreatedNotification()
            {
                Id = entry.Entity.Id
            }, cancellationToken);
        }
    }
}
