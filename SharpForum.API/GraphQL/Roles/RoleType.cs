﻿using HotChocolate;
using HotChocolate.Types;
using SharpForum.API.Data.Repository.Interfaces;
using SharpForum.API.Models.Domain;
using System.Collections.Generic;
using System.Linq;

namespace SharpForum.API.GraphQL.Roles
{
    public class RoleType : ObjectType<Role>
    {
        protected override void Configure(IObjectTypeDescriptor<Role> descriptor)
        {
            descriptor
                .Description("Roles");

            descriptor
                .Field(x => x.Id)
                .Description("Globally unique identifier (GUID)");

            descriptor
                .Field(x => x.Name)
                .Description("Role name");

            descriptor
                .Field(x => x.Users)
                //.Type<Users.UserType>()
                .ResolveWith<Resolvers>(x => x.GetUsers(default!, default!))
                .Description("List of users in role")
                .UseFiltering()
                .UseSorting();
        }

        private class Resolvers
        {
            public async Task<IEnumerable<User>> GetUsers([Parent] Role role, [Service] ISharpForumData data)
            {
                var users = await data.Users.GetAllCachedAsync();

                return users.Where(x => x.RoleId == role.Id);
            }
        }
    }
}