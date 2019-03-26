using FeatureSlice.Core.Models;
using FeatureSlice.Data.Entities;
using System;
using System.Linq.Expressions;

namespace FeatureSlice.Core.Repository
{
    public static class UserModelEx
    {
        public static readonly Expression<Func<UserEntity, UserModel>> ReadFrom =
            user => new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
    }
}