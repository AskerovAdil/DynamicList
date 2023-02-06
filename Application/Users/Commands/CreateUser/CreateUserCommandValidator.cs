using FluentValidation;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator() {
            RuleFor(createUserCommand =>
                createUserCommand.FIO).MaximumLength(250);
            RuleFor(createUserCommand =>
                createUserCommand.FIO).MinimumLength(10);
            RuleFor(createUserCommand =>
                createUserCommand.IsMale).NotEmpty();
            RuleFor(createUserCommand =>
                createUserCommand.City).MaximumLength(50);
            RuleFor(createUserCommand =>
                createUserCommand.Country).MaximumLength(50);
            RuleFor(createUserCommand =>
                createUserCommand.BirthDay).NotEmpty();
        }
    }
}
