using MediatR;
using SharpForum.Domain;
using SharpForum.Repository.Interfaces;

namespace SharpForum.Application.Categories
{
    public class Details
    {
        public class Query : IRequest<Category>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Category>
        {
            private readonly ISharpForumData _data;

            public Handler(ISharpForumData sharpForumData)
            {
                _data = sharpForumData;
            }

            public async Task<Category> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _data.Categories.GetByIdAsync(request.Id);
            }
        }
    }
}