using FluentValidation;
using Rise.Phone.Api.Models.Phone;
using Rise.Phone.Api.Validators.Messages;

namespace Rise.Phone.Api.Validators.Phone
{
    public partial class PersonValidator : BaseFluentValidator<PersonModel>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(PersonValidationMessage.NameNotEmpty);
        }
    }
}
