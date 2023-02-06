using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetSortedListQuery
{
    public class GetSortedListQueryHandler : IRequestHandler<GetSortedListQuery, List<User>>
    {
        private readonly IUserDbContext _userDbContext;
        public GetSortedListQueryHandler(IUserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public async Task<List<User>> Handle(GetSortedListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<User> users = _userDbContext.Users;

            users = request.ParametrSort switch
            {
                SortState.FIOAsc => users.OrderByDescending(s => s.FIO),
                SortState.FIODesc => users.OrderBy(s => s.FIO),
                SortState.BirthDayAsc => users.OrderByDescending(s => s.BirthDay),
                SortState.BirthDayDesc => users.OrderBy(s => s.BirthDay),
                SortState.CountryAsc => users.OrderByDescending(s => s.Country),
                SortState.CountryDesc => users.OrderBy(s => s.Country),
                SortState.CityDesc => users.OrderByDescending(s => s.City),
                SortState.CityAsc => users.OrderBy(s => s.City),
                _ => users.OrderBy(s => s.FIO),
            };

            return users.ToList();
        }
    }

}
