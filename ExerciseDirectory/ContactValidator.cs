using FluentValidation;
namespace ExerciseDirectory;
public class ContactValidator : AbstractValidator<Contact>
{
    public ContactValidator(Query query)
    {
        Include(new nameValidationClass(query));
        Include(new landlineValidationClass());
        Include(new cellphoneValidationClass());
    }
}
public class nameValidationClass : AbstractValidator<Contact>
{
    public nameValidationClass(Query query)
    {
        RuleFor(contact => contact.nameContact).NotEmpty().WithMessage("The name cannot be empty").MaximumLength(50).WithMessage("The name can have a maximum of 50 characters").Must(query.consultContactexist).WithMessage("The name you are trying to add is already registered, try another").Matches("^[a-zA-Z ]+$").WithMessage("You must enter only letters to define the name of the contact");
    }
}

public class nameValidationMultiuseClass : AbstractValidator<Contact>
{
    public nameValidationMultiuseClass()
    {
        RuleFor(contact => contact.nameContact).NotEmpty().WithMessage("The name cannot be empty").MaximumLength(50).WithMessage("The name can have a maximum of 50 characters").Matches("^[a-zA-Z ]+$").WithMessage("You must enter only letters to define the name of the contact");
    }
}

public class landlineValidationClass : AbstractValidator<Contact>
{
    public landlineValidationClass()
    {
        RuleFor(contact => contact.landlineContact).NotEmpty().WithMessage("The landline cannot be empty").MaximumLength(15).WithMessage("The landline can have a maximum of 15 characters").Matches("^[0-9]+$").WithMessage("You must enter only numerical values to define the landline");
    }
}

public class cellphoneValidationClass : AbstractValidator<Contact>
{
    public cellphoneValidationClass()
    {
        RuleFor(contact => contact.cellphoneContact).NotEmpty().WithMessage("The cellphone cannot be empty").MaximumLength(15).WithMessage("The cellphone can have a maximum of 15 characters").Matches("^[0-9]+$").WithMessage("You must enter only numerical values to define the cellphone");
    }
}