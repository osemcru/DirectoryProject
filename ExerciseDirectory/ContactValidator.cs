using FluentValidation;


namespace ExerciseDirectory;


public class ContactValidator : AbstractValidator<Contact>
{
    public ContactValidator()
    {
        Include(new nameValidationClass());
        Include(new landlineValidationClass());
        Include(new cellphoneValidationClass());
    }

}
public class nameValidationClass : AbstractValidator<Contact>
{
    public nameValidationClass()
    {
        Directory directory;
        List<Contact> listContact = new List<Contact>();
        Query query = new Query(listContact);
        RuleFor(contact => contact.nameContact).NotEmpty().WithMessage("the name cannot be empty").MaximumLength(50).WithMessage("the name can have a maximum of 50 characters").Must(query.consultContactexist).WithMessage("the name you are trying to add is already registered, try another");
    }
}

public class landlineValidationClass : AbstractValidator<Contact>
{
    public landlineValidationClass()
    {
        RuleFor(contact => contact.landlineContact).NotEmpty().WithMessage("the landline cannot be empty").MaximumLength(15).WithMessage("the landline can have a maximum of 15 characters");
    }
}

public class cellphoneValidationClass : AbstractValidator<Contact>
{
    public cellphoneValidationClass()
    {
        RuleFor(contact => contact.cellphoneContact).NotEmpty().WithMessage("the cellphone cannot be empty").MaximumLength(15).WithMessage("the cellphone can have a maximum of 15 characters");
    }
}