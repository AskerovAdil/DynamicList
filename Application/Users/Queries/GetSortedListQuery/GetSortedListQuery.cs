using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetSortedListQuery
{
    public class GetSortedListQuery : IRequest<List<User>>
    {
        public SortState ParametrSort { get; set; }
    }
    public enum SortState
    {
        FIOAsc,    // по имени по возрастанию
        BirthDayAsc, // по возрасту по возрастанию
        CountryAsc, // по компании по возрастанию
        CityAsc,    // по возрасту по убыванию
        FIODesc,    // по имени по возрастанию
        CityDesc,    // по возрасту по убыванию
        CountryDesc,    // по возрасту по убыванию
        BirthDayDesc,    // по возрасту по убыванию
    }
}
