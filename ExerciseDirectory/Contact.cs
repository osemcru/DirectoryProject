namespace ExerciseDirectory;
public class Contact
{
    public string nameContact { get; set; }
    public string landlineContact { get; set; }
    public string cellphoneContact { get; set; }

    public Contact(string nameContact, string landlineContact, string cellphoneContact)
    {
        this.nameContact = nameContact;
        this.landlineContact = landlineContact;
        this.cellphoneContact = cellphoneContact;
    }
    public Contact(string nameContact)
    {
        this.nameContact = nameContact;
    }
     public Contact()
    {
    }




}