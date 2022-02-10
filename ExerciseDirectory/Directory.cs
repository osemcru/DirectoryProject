namespace ExerciseDirectory;
public class Directory
{
    List<Contact> listContact = new List<Contact>();
    Message message = new Message();
    Query query;
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
    public bool addContact(Contact contact)
    {
        try
        {
            if (!fullDirectory())
            {
                if (!isContactExist(contact))
                {
                    listContact.Add(contact);
                    message.addContactMessage(contact.nameContact);
                    return true;
                }
            }
        }
        catch (Exception)
        {
            message.errorMessage();
        }
        message.notAddContactMessage(contact.nameContact);
        return false;
    }

    public bool isContactExist(Contact contact)
    {
        try
        {
            Contact contactQuery = query.consultContact(contact.nameContact);
            if (contactQuery != null)
            {
                message.ifContactExistMessage();
                return true;
            }
        }
        catch (Exception)
        {
            message.errorMessage();
        }
        message.ifContactNotExistMessage();
        return false;
    }

    public bool listContacts()
    {
        try
        {
            if (listContact.Count() != 0)
            {
                listContact.ForEach((i) => message.printListContacts(i));
                return true;
            }
        }
        catch (Exception)
        {
            message.errorMessage();
        }
        message.messageVoidListContacts();
        return false;
    }

    public bool findContact(string name)
    {
        try
        {
            Contact contactQuery = query.consultContact(name);
            if (contactQuery != null)
            {
                message.ifContactIsFoundMessage(contactQuery.landlineContact);
                return true;
            }
        }
        catch (Exception)
        {
            message.errorMessage();
        }
        message.ifContactIsNotFoundMessage();
        return false;
    }

    public bool deleteContact(Contact contact)
    {
        try
        {
            Contact contactQuery = query.consultContact(contact.nameContact);
            if (contactQuery != null)
            {
                if (listContact.Remove(contactQuery))
                {
                    message.deleteContactMessage(contactQuery.nameContact);
                    return true;
                }
            }
        }
        catch (Exception)
        {
            message.errorMessage();
        }
        message.notDeleteContactMessage(contact.nameContact);
        return false;
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
