﻿using HotChocolate.Types;
using HotChocolate;
using SharpForum.API.GraphQL.Users;
using SharpForum.API.Services.Security;
using SharpForum.API.Data.Repository.Interfaces;

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
    }
}