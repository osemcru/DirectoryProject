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
    public void addContact(Contact contact)
    {
        try
        {
            if (!fullDirectory())
            {
                if (!isContactExist(contact))
                {
                    listContact.Add(contact);
                    message.addContactMessage(contact.nameContact);
                }
                else
                {
                    message.notAddContactMessage(contact.nameContact);
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
