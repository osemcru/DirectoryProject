using FluentValidation.Results;
namespace ExerciseDirectory;
public class Directory
{
    List<Contact> listContact = new List<Contact>();
    Message message = new Message();
    Query query;
    nameValidationMultiuseClass nameValidator;
    byte size;
    public Directory(byte size)
    {
        this.size = size;
    }

    public Query getQuery()
    {
        try
        {
            query = new Query(listContact);
        }
        catch (Exception)
        {
            message.errorMessage();
        }
        return query;
    }
    public void addContact(Contact contact)
    {
        try
        {
            if (!fullDirectory())
            {
                ContactValidator contactValidator = new ContactValidator(query);
                ValidationResult resultValidation = contactValidator.Validate(contact);
                if (!resultValidation.IsValid)
                {
                    message.notAddContactMessage(contact.nameContact);
                    resultValidation.Errors.ForEach((i) => message.contactValidatorMessage(i));
                }
                else
                {
                    listContact.Add(contact);
                    message.addContactMessage(contact.nameContact);
                }
            }
        }
        catch (Exception)
        {
            message.errorMessage();
        }
    }

    public bool isContactExist(Contact contact)
    {
        try
        {
            nameValidator = new nameValidationMultiuseClass();
            ValidationResult resultValidation = nameValidator.Validate(contact);
            if (!resultValidation.IsValid)
            {
                resultValidation.Errors.ForEach((i) => message.contactValidatorMessage(i));
            }
            else
            {
                Contact contactQuery = query.consultContact(contact.nameContact);
                if (contactQuery != null)
                {
                    message.ifContactExistMessage();
                    return true;
                }
                else
                {
                    message.ifContactNotExistMessage();
                }
            }
        }
        catch (Exception)
        {
            message.errorMessage();
        }
        return false;
    }

    public List<Contact> listContacts()
    {
        try
        {
            if (listContact.Count() != 0)
            {
                listContact.ForEach((i) => message.printListContacts(i));
            }
            else
            {
                message.messageVoidListContacts();
            }
        }
        catch (Exception)
        {
            message.errorMessage();
        }
        return listContact;
    }

    public Contact findContact(string name)
    {
        Contact contactQuery = null;
        try
        {
            nameValidator = new nameValidationMultiuseClass();
            Contact contact = new Contact(name);
            ValidationResult result = nameValidator.Validate(contact);
            if (!result.IsValid)
            {
                result.Errors.ForEach((i) => message.contactValidatorMessage(i));
            }
            else
            {
                contactQuery = query.consultContact(name);
                if (contactQuery != null)
                {
                    message.ifContactIsFoundMessage(contactQuery.landlineContact);
                    return contactQuery;
                }
                else
                {
                    message.ifContactIsNotFoundMessage();
                }
            }
        }
        catch (Exception)
        {
            message.errorMessage();
        }
        return contactQuery;
    }

    public void deleteContact(Contact contact)
    {
        try
        {
            nameValidator = new nameValidationMultiuseClass();
            ValidationResult result = nameValidator.Validate(contact);
            if (!result.IsValid)
            {
                result.Errors.ForEach((i) => message.contactValidatorMessage(i));
            }
            else
            {
                Contact contactQuery = query.consultContact(contact.nameContact);
                if (contactQuery != null)
                {
                    if (listContact.Remove(contactQuery))
                        message.deleteContactMessage(contactQuery.nameContact);
                }
                else
                {
                    message.notDeleteContactMessage(contact.nameContact);
                }
            }
        }
        catch (Exception)
        {
            message.errorMessage();
        }
    }

    public bool fullDirectory()
    {
        try
        {
            if (listContact.Count == size)
            {
                message.fullDirectoryMessage();
                return true;
            }
        }
        catch (Exception)
        {
            message.errorMessage();
        }
        message.notFullDirectoryMessage();
        return false;
    }

    public byte freeSpaces()
    {
        byte space = 0;
        try
        {
            space = Convert.ToByte(size - listContact.Count());
            message.freeSpaceMessage(space);
        }
        catch (Exception)
        {
            message.errorMessage();
        }
        return space;
    }

}
