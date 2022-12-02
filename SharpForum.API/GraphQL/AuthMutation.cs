using HotChocolate.Types;
using HotChocolate;
using SharpForum.API.GraphQL.Users;
using SharpForum.API.Services.Security;
using SharpForum.API.Data.Repository.Interfaces;
using SharpForum.API.Models.Domain;
using System.Linq;

namespace SharpForum.API.GraphQL
{
    [ExtendObjectType(typeof(Mutation))]
    [GraphQLDescription("Authorization mutations")]
    public class AuthMutation
    {
        public async Task<LoginUserPayload> LoginUserAsync(
            LoginUserInput input,
            [Service] ISharpForumData data,
            [Service] IPasswordService passwordService,
            [Service] ITokenService tokenService)
        {
            var user =
                await data.Users.GetByDisplayNameAsync(input.DisplayName);

            if (user == null)
                throw new GraphQLException(new Error("User not found"));

            if (user.Removed)
                throw new GraphQLException(new Error("User is removed"));

            var passwordMatch =
                passwordService.CheckPassword(input.Password, user.PasswordHash);

            if (passwordMatch)
            {
                var expiration = DateTime.UtcNow.AddDays(1);

                string token = tokenService.CreateToken(user, expiration);

                return new LoginUserPayload(token, expiration, user);
            }

            throw new GraphQLException(new Error("Unauthorized"));
        }

        public async Task<RegisterUserPayload> RegisterUserAsync(
            RegisterUserInput input,
            [Service] ISharpForumData data,
            [Service] IPasswordService passwordService,
            [Service] ITokenService tokenService)
        {
            var user =
                await data.Users.GetByDisplayNameAsync(input.DisplayName);

            if (user != null)
                throw new GraphQLException(new Error("User already registered"));

            if (!string.IsNullOrWhiteSpace(input.Email))
            {
                user =
                    await data.Users.GetByEmailAsync(input.Email);

                if (user != null)
                    throw new GraphQLException(new Error("User already registered"));
            }

            var passwordHash =
                passwordService.GetPasswordHash(input.Password);

            var roles =
                await data.Roles.GetAllAsync();

            var defaultRole =
                roles.Where(x => x.Name == "User").FirstOrDefault();

            var id = Guid.NewGuid();

            user = new User()
            {
                Id = id,
                About = string.Empty,
                Avatar = $"https://robohash.org/{id}?set=set4",
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                DisplayName = input.DisplayName,
                Email = input.Email ?? string.Empty,
                Location = string.Empty,
                PasswordHash = passwordHash,
                Removed = false,
                RoleId = defaultRole.Id,
                Signature = string.Empty,
                Website = string.Empty
            };

            bool success = await data.Users.AddAsync(user);

            user.Role = defaultRole;

            if (!success)
                throw new GraphQLException(new Error("Problem adding user."));

            var expiration = DateTime.UtcNow.AddDays(1);

            string token = tokenService.CreateToken(user, expiration);

            return new RegisterUserPayload(token, expiration, user);
        }
    }
}