using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetFindUsersList;
using Application.Users.Queries.GetSortedListQuery;
using Application.Users.Queries.GetUsersList;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            var query = new GetUsersListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetSorted(SortState sortState)
        {
            var query = new GetSortedListQuery();
            query.ParametrSort = sortState;
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }


        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserCommand createUser)
        {
            var vm = await Mediator.Send(createUser);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> GetFindUser([FromBody]GetFindUserQuery FindParametr)
        {
            var vm = await Mediator.Send(FindParametr);

            return Ok(vm);
        }




    }
}
