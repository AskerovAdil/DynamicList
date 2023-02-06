using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetFindUsersList
{
    public class GetFindUserQuery : IRequest<List<User>>
    {
        public string? FIO { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool isFIO { get; set; }
    }
}
