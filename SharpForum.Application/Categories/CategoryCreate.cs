using MediatR;
using SharpForum.Application.Core;
using SharpForum.Application.Validators;
using SharpForum.Repository.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SharpForum.Application.Categories
{
    public class CategoryCreate
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Category Category { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Category).SetValidator(new CategoryValidator());
            }
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
                request.Category.CreatedOn = DateTime.UtcNow;
                request.Category.UpdatedOn = DateTime.UtcNow;
                request.Category.Id = Guid.NewGuid();

                await _data.Categories.AddAsync(request.Category);

                var success = await _data.SaveAsync();

                if (!success) return Result<Unit>.Failure("Failed to create category");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}