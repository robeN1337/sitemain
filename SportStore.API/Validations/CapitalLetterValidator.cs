using FluentValidation;
using SportStore.API.Entities;

namespace SportStore.API.Validations
{
    public class CapitalLetterValidator : AbstractValidator<User>
    {
        public CapitalLetterValidator() 
        {
            RuleFor(u => u.Username).Must(StartsWithCapitalLetter).WithMessage("Имя пользователя должно начинаться с заглавной буквы!");

        }

        private bool StartsWithCapitalLetter(string username)
        {
            return char.IsUpper(username[0]);
        }
    }
}
