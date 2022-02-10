using FluentValidation.Results;
namespace ExerciseDirectory;
public class MethodsMenu
{
    byte directorySize;
    Message message = new Message();
    Directory directory;
    ContactValidator contactValidator;
    public Directory consultDirectorySize()
    {
        directorySize = 0;
        do
        {
            try
            {
                directorySize = message.getConsultSize();
                if (directorySize > 0 && directorySize <= 10)
                {
                    directory = new Directory(directorySize);
                    contactValidator = new ContactValidator(directory.getQuery());
                    return directory;
                }
                message.invalidOptionSize();
            }
            catch (Exception)
            {
                message.errorMessageMenu();
            }
        } while (directorySize <= 0 || directorySize > 10);
        return directory;
    }
    public void addContactOption()
    {
        try
        {
            if (!directory.fullDirectory())
            {
                Contact contact = new Contact(message.obtainNameContact(), message.obtainLandlineContact(), message.obtainCellphoneContact());
                ValidationResult result = contactValidator.Validate(contact);
                if (!result.IsValid)
                {
                    result.Errors.ForEach((i) => message.contactValidatorMessage(i));
                }
                else
                {
                    directory.addContact(contact);
                }
            }
        }
        catch (Exception)
        {
            message.errorMessage();
        }
    }
    public void isContactExistOption()
    {
        try
        {
            nameValidationMultiuseClass nameValidator = new nameValidationMultiuseClass();
            Contact contact = new Contact(message.obtainNameContact());
            ValidationResult result = nameValidator.Validate(contact);
            if (!result.IsValid)
            {
                result.Errors.ForEach((i) => message.contactValidatorMessage(i));
            }
            else
            {
                directory.isContactExist(contact);
            }
        }
        catch (Exception)
        {
            message.errorMessage();
        }
    }
    public void fullDirectoryOption()
    {
        try
        {
            directory.fullDirectory();
        }
        catch (Exception)
        {
            message.errorMessage();
        }
    }
    public void listContactsOption()
    {
        try
        {
            directory.listContacts();
        }
        catch (Exception)
        {
            message.errorMessage();
        }
    }
    public void findContactsOption()
    {
        try
        {
            nameValidationMultiuseClass nameValidator = new nameValidationMultiuseClass();
            Contact contact = new Contact(message.obtainNameContact());
            ValidationResult result = nameValidator.Validate(contact);
            if (!result.IsValid)
            {
                result.Errors.ForEach((i) => message.contactValidatorMessage(i));
            }
            else
            {
                directory.findContact(contact.nameContact);
            }
        }
        catch (Exception)
        {
            message.errorMessage();
        }
    }
    public void availableContactsOption()
    {
        try
        {
            directory.freeSpaces();
        }
        catch (Exception)
        {
            message.errorMessage();
        }
    }
    public void deleteContactOption()
    {
        try
        {
            nameValidationMultiuseClass nameValidator = new nameValidationMultiuseClass();
            Contact contact = new Contact(message.obtainNameContact());
            ValidationResult result = nameValidator.Validate(contact);
            if (!result.IsValid)
            {
                result.Errors.ForEach((i) => message.contactValidatorMessage(i));
            }
            else
            {
                directory.deleteContact(contact);
            }
        }
        catch (Exception)
        {
            message.errorMessage();
        }
    }
}