using MediatR;
using SharpForum.Domain;
using SharpForum.Repository.Interfaces;

namespace SharpForum.Application.Categories
{
    public class List
    {
        public class Query : IRequest<IEnumerable<Category>> 
        { 
            // Query parameters goes here
        }

        public class Handler : IRequestHandler<Query, IEnumerable<Category>>
        {
            private readonly ISharpForumData _data;

            public Handler(ISharpForumData sharpForumData)
            {
                _data = sharpForumData;
            }

            public async Task<IEnumerable<Category>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _data.Categories.GetAllAsync();
            }
        }
    }
}