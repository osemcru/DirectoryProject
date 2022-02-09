using FluentValidation.Results;
namespace ExerciseDirectory;
public class MethodsMenu
{
    byte directorySize;
    Message message = new Message();
    Directory directory;
    ContactValidator contactValidator = new ContactValidator();
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
                    return directory;
                }
            }
            catch (Exception)
            {
                message.errorMessage();
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
        catch (Exception e)
        {
            Console.Write(e);
        }
    }
    public void isContactExistOption()
    {
        try
        {
            Contact contact = new Contact(message.obtainNameContact());
            directory.isContactExist(contact);
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
            directory.findContact(message.obtainNameContact());
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
            Contact contact = new Contact(message.obtainNameContact());
            directory.deleteContact(contact);
        }
        catch (Exception)
        {
            message.errorMessage();
        }
    }
}