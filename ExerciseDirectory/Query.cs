namespace ExerciseDirectory;
public class Query
{
    List<Contact> listContact = new List<Contact>();
    Message message = new Message();
    public Query(List<Contact> listContact)
    {
        this.listContact = listContact;
    }
    public Contact consultContact(string name)
    {
        Contact contactFind = new Contact();
        try
        {
            contactFind =
              listContact.Where(c => c.nameContact == name).FirstOrDefault();
        }
        catch (Exception)
        {
            message.errorMessage();
        }
        return contactFind;
    }

    public bool consultContactexist(string name)
    {
        Contact contactFind = new Contact();
        try
        {
            contactFind =
              listContact.Where(c => c.nameContact == name).FirstOrDefault();
            if (contactFind == null) return true;
        }
        catch (Exception)
        {
            message.errorMessage();
        }
        return false;
    }



}