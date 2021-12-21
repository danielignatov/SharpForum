using MediatR;
using SharpForum.Application.Core;
using SharpForum.Application.Validators;
using SharpForum.Repository.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SharpForum.Application.Categories
{
    public class CategoryEdit
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
                var category = await _data.Categories.GetByIdAsync(request.Category.Id);
                category.UpdatedOn = DateTime.UtcNow;
                category.Description = request.Category.Description;
                category.Name = request.Category.Name;
                category.Order = request.Category.Order;
                category.Removed = request.Category.Removed;

                _data.Categories.Update(category);

                var success = await _data.SaveAsync();

                if (!success) return Result<Unit>.Failure("Failed to edit category");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
