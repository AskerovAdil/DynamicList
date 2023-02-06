using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUsersList
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, List<User>>
    {
        private readonly IUserDbContext _userDbContext;
        public GetUsersListQueryHandler(IUserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public async Task<List<User>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var usersList = await _userDbContext.Users.ToListAsync();

            return usersList;
        }
    }
}
