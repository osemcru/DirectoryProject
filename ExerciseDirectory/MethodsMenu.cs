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
                directory.addContact(contact);
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
            Contact contact = new Contact(message.obtainNameContact());
            directory.findContact(contact.nameContact);
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