using MediatR;
using SharpForum.Application.Core;
using SharpForum.Application.Validators;
using SharpForum.Repository.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SharpForum.Application.Topics
{
    public class TopicCreate
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Topic Topic { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Topic).SetValidator(new TopicValidator());
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
                request.Topic.CreatedOn = DateTime.UtcNow;
                request.Topic.UpdatedOn = DateTime.UtcNow;
                request.Topic.Id = Guid.NewGuid();

                await _data.Topics.AddAsync(request.Topic);

                var success = await _data.SaveAsync();

                if (!success) return Result<Unit>.Failure("Failed to create category");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
