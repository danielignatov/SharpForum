using MediatR;
using SharpForum.Application.Core;
using SharpForum.Repository.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SharpForum.Application.Categories
{
    public class CategoryDetails
    {
        public class Query : IRequest<Result<Category>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Category>>
        {
            private readonly ISharpForumData _data;

            public Handler(ISharpForumData sharpForumData)
            {
                _data = sharpForumData;
            }

            public async Task<Result<Category>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<Category>.Success(await _data.Categories.GetByIdAsync(request.Id));
            }
        }
    }
}