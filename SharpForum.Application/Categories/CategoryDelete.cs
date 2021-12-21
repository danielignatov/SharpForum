using MediatR;
using SharpForum.Application.Core;
using SharpForum.Repository.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SharpForum.Application.Categories
{
    public class CategoryDelete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly ISharpForumData _data;

            public Handler(ISharpForumData sharpForumData)
            {
                _data = sharpForumData;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                await _data.Categories.DeleteAsync(request.Id);

                var success = await _data.SaveAsync();

                if (!success) return Result<Unit>.Failure("Failed to delete category");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}