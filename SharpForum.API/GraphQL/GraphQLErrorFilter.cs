using HotChocolate;

namespace SharpForum.API.GraphQL
{
    public class GraphQLErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            return error.WithMessage(error?.Exception?.Message ?? error.Message);
        }
    }
}