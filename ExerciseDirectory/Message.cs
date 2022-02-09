using FluentValidation.Results;

namespace ExerciseDirectory;
public class Message
{
    public byte getConsultSize()
    {
        try
        {
            string consultSize = "Enter the number of contacts to save between 1 and 10: ";
            Console.Write(consultSize);
        }
        catch (Exception)
        {
            errorMessage();
        }
        return Convert.ToByte(Console.ReadLine());
    }
    public void errorMessage()
    {
        try
        {
            string error = "An error has occurred \n";
            Console.Write(error);
        }
        catch (Exception)
        {
            errorMessage();
        }
    }
    public void invalidOption()
    {
        try
        {
            string error = "this is an invalid option \n";
            Console.Write(error);
        }
        catch (Exception)
        {
            errorMessage();
        }
    }
    public void menuOptions()
    {
        try
        {
            string options = " \n 1. Add Contact \n 2. List Contacts \n 3. Find Contact \n 4. There Is Contact \n 5. Delete Contact \n 6. Available Contacts \n 7. Full Directory \n 8. Exit \n ___________________ \n    Enter The Number Of The Operation: ";
            Console.Write(options);
        }
        catch (Exception)
        {
            errorMessage();
        }
    }
    public void fullDirectoryMessage()
    {
        try
        {
            string message = "Directory is full \n";
            Console.Write(message);
        }
        catch (Exception)
        {
            errorMessage();
        }
    }
    public void notFullDirectoryMessage()
    {
        try
        {
            string message = "Directory has available space \n";
            Console.Write(message);
        }
        catch (Exception)
        {
            errorMessage();
        }
    }
    public void ifContactExistMessage()
    {
        try
        {
            string message = "The contact is already registered \n";
            Console.Write(message);
        }
        catch (Exception)
        {
            errorMessage();
        }
    }
    public void ifContactNotExistMessage()
    {
        try
        {
            string message = "The contact is not registered \n";
            Console.Write(message);
        }
        catch (Exception)
        {
            errorMessage();
        }
    }
    public string obtainNameContact()
    {
        try
        {
            string message = "Enter the name of the contact:  ";
            Console.Write(message);
        }
        catch (Exception)
        {
            errorMessage();
        }
        return Convert.ToString(Console.ReadLine());
    }
    public string obtainLandlineContact()
    {
        try
        {
            string message = "Enter the contact's landline:  ";
            Console.Write(message);
        }
        catch (Exception)
        {
            errorMessage();
        }
        return Convert.ToString(Console.ReadLine());
    }
    public string obtainCellphoneContact()
    {
        try
        {
            string message = "Enter the contact cell phone:  ";
            Console.Write(message);
        }
        catch (Exception)
        {
            errorMessage();
        }
        return Convert.ToString(Console.ReadLine());
    }
    public void addContactMessage(string name)
    {
        try
        {
            string message = "The contact " + name + " has been added \n";
            Console.Write(message);
        }
        catch (Exception)
        {
            errorMessage();
        }
    }
    public void contactValidatorMessage(ValidationFailure i)
    {
        try
        {
            string message = $"Error in {i.PropertyName} {i.ErrorMessage} \n";
            Console.Write(message);
        }
        catch (Exception)
        {
            errorMessage();
        }
    }
    public void notAddContactMessage(string name)
    {
        try
        {
            string message = "The contact " + name + " has not been added \n";
            Console.Write(message);
        }
        catch (Exception)
        {
            errorMessage();
        }
    }
    public void printListContacts(Contact i)
    {
        try
        {
            string message = i.nameContact + " with landline " + i.landlineContact + " and cellphone " + i.cellphoneContact;
            Console.WriteLine(message);
        }
        catch (Exception)
        {
            errorMessage();
        }
    }
    public void messageVoidListContacts()
    {
        try
        {
            string message = "This list is void";
            Console.WriteLine(message);
        }
        catch (Exception)
        {
            errorMessage();
        }
    }
    public void ifContactIsFoundMessage(string landline)
    {
        try
        {
            string message = "the contact has been found and his landline is " + landline + "\n";
            Console.Write(message);
        }
        catch (Exception)
        {
            errorMessage();
        }
    }
    public void ifContactIsNotFoundMessage()
    {
        try
        {
            string message = "the contact has not been found \n";
            Console.Write(message);
        }
        catch (Exception)
        {
            errorMessage();
        }
    }
    public void freeSpaceMessage(byte space)
    {
        try
        {
            string message = "The number of available contacts is " + space + "\n";
            Console.Write(message);
        }
        catch (Exception)
        {
            errorMessage();
        }
    }
    public void deleteContactMessage(string name)
    {
        try
        {
            string message = "The contact " + name + " has been deleted \n";
            Console.Write(message);
        }
        catch (Exception)
        {
            errorMessage();
        }
    }
    public void notDeleteContactMessage(string name)
    {
        try
        {
            string message = "The contact " + name + " has not been deleted \n";
            Console.Write(message);
        }
        catch (Exception)
        {
            errorMessage();
        }
    }
    public void exitMessage()
    {
        try
        {
            string message = "It was a pleasure serving you, until next time! \n";
            Console.Write(message);
        }
        catch (Exception)
        {
            errorMessage();
        }
    }
}