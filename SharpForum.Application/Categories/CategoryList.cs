using MediatR;
using SharpForum.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SharpForum.Application.Categories
{
    public class CategoryList
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