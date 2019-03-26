using FeatureSlice.Core.Models;
using FeatureSlice.Core.Repository;
using FeatureSlice.Data;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FeatureSlice.Features.Users.Query
{
    public sealed class GetUsersQuery : IRequest<List<UserModel>>
    {
        public Guid? Id { get; set; }
    }

    internal sealed class GetlAllUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserModel>>
    {
        private readonly DataContext _dataContext;

        public GetlAllUsersQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<UserModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _dataContext.Users.AsExpandable();

            if (request.Id.HasValue)
            {
                users = users.Where(u => u.Id == request.Id);
            }

            return await users
                .Select(user => UserModelEx.ReadFrom.Invoke(user))
                .ToListAsync(cancellationToken);
        }
    }
}