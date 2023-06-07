using System;
using FluentValidation;
using Shared;

namespace Quize_App.Models.Users
{
    public class UserUpdateRequest
    {
        public string Id { get; set; } = null!;
        public string Username { get; set; } = null!;
    }

    public class UserUpdateRequestValidator : AbstractValidator<UserUpdateRequest>
    {
        public UserUpdateRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(ErrMessages.IdEmpty);

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage(ErrMessages.UsernameEmpty);
        }
    }
}

