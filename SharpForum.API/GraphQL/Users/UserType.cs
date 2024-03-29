﻿using HotChocolate.Types;
using HotChocolate;
using SharpForum.API.Data.Repository.Interfaces;
using SharpForum.API.Models.Domain;
using System.Collections.Generic;
using System.Linq;

namespace SharpForum.API.GraphQL.Users
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor
                .Description("Users");

            descriptor
                .Field(x => x.About)
                .Description("User about info");

            descriptor
                .Field(x => x.Avatar)
                .Description("User display image");

            descriptor
                .Field(x => x.CreatedOn)
                .Description("User creation date and time (in UTC)");

            descriptor
                .Field(x => x.DisplayName)
                .Description("User display name");

            descriptor
                .Field(x => x.Email)
                .Description("User email address");

            descriptor
                .Field(x => x.Id)
                .Description("Globally unique identifier (GUID)");

            descriptor
                .Field(x => x.Location)
                .Description("User location info");

            descriptor
                .Field(x => x.PasswordHash)
                .Ignore();

            descriptor
                .Field(x => x.Removed)
                .Description("User is considered as removed");

            descriptor
                .Field(x => x.Replies)
                .ResolveWith<Resolvers>(x => x.GetReplies(default!, default!))
                .Description("List of replies the user is author")
                .UseFiltering()
                .UseSorting();

            descriptor
                .Field(x => x.Signature)
                .Description("User text under replies and topics");

            descriptor
                .Field(x => x.RoleId)
                .Description("User role identifier");

            descriptor
                .Field(x => x.Role)
                .ResolveWith<Resolvers>(x => x.GetRole(default!, default!))
                .Description("User role");

            descriptor
                .Field(x => x.Topics)
                .ResolveWith<Resolvers>(x => x.GetTopics(default!, default!))
                .Description("List of topics the user is author")
                .UseFiltering()
                .UseSorting();

            descriptor
                .Field(x => x.UpdatedOn)
                .Description("Last updated date and time (in UTC)");

            descriptor
                .Field(x => x.Website)
                .Description("User website address");

            descriptor
                .Field("postCount")
                .ResolveWith<Resolvers>(x => Resolvers.GetPostCount(default!, default!))
                .Description("Total count of user created topics and replies");
        }

        private class Resolvers
        {
            public async Task<IEnumerable<Topic>> GetTopics([Parent] User user, [Service] ISharpForumData data)
            {
                return await data.Topics.GetByAuthorAsync(user.Id);
            }

            public async Task<IEnumerable<Reply>> GetReplies([Parent] User user, [Service] ISharpForumData data)
            {
                return await data.Replies.GetByAuthorAsync(user.Id);
            }

            public async Task<Role> GetRole([Parent] User user, [Service] ISharpForumData data)
            {
                return await data.Roles.GetByIdAsync(user.RoleId);
            }

            public static async Task<int> GetPostCount([Parent] User user, [Service] ISharpForumData data)
            {
                return await data.Users.GetPostCountAsync(user.Id);
            }
        }
    }
}