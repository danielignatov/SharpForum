using MediatR;
using SharpForum.Application.Core;
using SharpForum.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SharpForum.Application.Categories
{
    public class CategoryList
    {
        public class Query : IRequest<Result<IEnumerable<Category>>> 
        { 
            // Query parameters goes here
        }

        public class Handler : IRequestHandler<Query, Result<IEnumerable<Category>>>
        {
            private readonly ISharpForumData _data;

            public Handler(ISharpForumData sharpForumData)
            {
                _data = sharpForumData;
            }

            public async Task<Result<IEnumerable<Category>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<IEnumerable<Category>>.Success(await _data.Categories.GetAllAsync());
            }
        }
    }
}