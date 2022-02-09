namespace ExerciseDirectory;
public class Menu
{
    public enum options : byte
    {
        AddContact = 1, ListContacts, FindContact, IsContactExist, DeleteContact, AvailableContacts, FullDirectory, Exit
    }
    public static void Main(string[] args)
    {
        Message message = new Message();
        MethodsMenu menu = new MethodsMenu();
        Directory directory = menu.consultDirectorySize();
        byte decision = 0;
        do
        {
            try
            {
                message.menuOptions();
                decision = Convert.ToByte(Console.ReadLine());

                switch (decision)
                {
                    case (byte)options.AddContact:
                        menu.addContactOption();
                        break;
                    case (byte)options.ListContacts:
                        menu.listContactsOption();
                        break;
                    case (byte)options.FindContact:
                        menu.findContactsOption();
                        break;
                    case (byte)options.IsContactExist:
                        menu.isContactExistOption();
                        break;
                    case (byte)options.DeleteContact:
                        menu.deleteContactOption();
                        break;
                    case (byte)options.AvailableContacts:
                        menu.availableContactsOption();
                        break;
                    case (byte)options.FullDirectory:
                        menu.fullDirectoryOption();
                        break;
                    case (byte)options.Exit:
                        message.exitMessage();
                        break;
                    default:
                        message.invalidOption();
                        break;
                }
            }
            catch (Exception)
            {
                message.errorMessage();
            }
        } while (decision != (byte)options.Exit);
    }
}