using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler
        : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserDbContext _userDbContext;
        public CreateUserCommandHandler(IUserDbContext userDbContext) =>
            _userDbContext = userDbContext;


        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                BirthDay = request.BirthDay,
                City = request.City,
                Country = request.Country,
                FIO = request.FIO,
                IsMale = request.IsMale
            };

            await _userDbContext.Users.AddAsync(user,cancellationToken);
            await _userDbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
