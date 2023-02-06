using Application.Interfaces;
using Application.Users.Queries.GetUsersList;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetFindUsersList
{
    public class GetFindUserHandler : IRequestHandler<GetFindUserQuery, List<User>>
    {
        private readonly IUserDbContext _userDbContext;
        public GetFindUserHandler(IUserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public async Task<List<User>> Handle(GetFindUserQuery request, CancellationToken cancellationToken)
        {
            List<User> result = new List<User>();

            if(request.isFIO)
                result = await _userDbContext.Users.Where(x => x.FIO.Trim() == request.FIO).ToListAsync();
            else
                result = await _userDbContext.Users.Where(x => x.BirthDay.Date == request.BirthDay.Value.Date).ToListAsync();

            return result;
        }
    }
}
