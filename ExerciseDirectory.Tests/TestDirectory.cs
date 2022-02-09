using Xunit;

namespace ExerciseDirectory.Tests;

public class UnitTest1
{
    [Theory]
    [InlineData("Carlos", "754937", "3146095976")]
    [InlineData("Rodolfo", "757383", "7493783218")]
    [InlineData("Fernando", "378574824", "312355645")]
    public void addContact(string name, string landline, string cellphone)
    {
        Contact contact = new Contact(name, landline, cellphone);
        Directory directory = new Directory(3);
        bool result = directory.addContact(contact);
        Assert.Equal(true, result);
    }

    [Theory]
    [InlineData("Pedro", "754937", "3146095976")]
    [InlineData("Arnoldo", "757383", "7493783218")]
    public void addContactRepeat(string name, string landline, string cellphone)
    {
        Contact contact = new Contact(name, landline, cellphone);
        Directory directory = new Directory(3);
        directory.addContact(contact);
        bool result = directory.addContact(contact);
        Assert.Equal(false, result);
    }

    [Fact]
    public void addContactFullDirectory()
    {
        Contact contact = new Contact("Teofilo", "45345435", "32342342");
        Contact contact2 = new Contact("Mateo", "45345", "343242342");
        Directory directory = new Directory(1);
        directory.addContact(contact);
        bool result = directory.addContact(contact2);
        Assert.Equal(false, result);
    }

    [Theory]
    [InlineData("Alfonso", "754937", "3146095976")]
    [InlineData("Roberto", "757383", "7493783218")]
    public void isContactExist(string name, string landline, string cellphone)
    {
        Contact contact = new Contact(name, landline, cellphone);
        Directory directory = new Directory(3);
        directory.addContact(contact);
        bool result = directory.isContactExist(contact);
        Assert.Equal(true, result);
    }

    [Theory]
    [InlineData("Alfonso", "754937", "3146095976")]
    [InlineData("Roberto", "757383", "7493783218")]
    public void isContactNotExist(string name, string landline, string cellphone)
    {
        Contact contact = new Contact(name, landline, cellphone);
        Contact contact2 = new Contact("Jonas", "545345345", "76234234");
        Directory directory = new Directory(3);
        directory.addContact(contact);
        bool result = directory.isContactExist(contact2);
        Assert.Equal(false, result);
    }

    [Theory]
    [InlineData("Alfonso", "754937", "3146095976")]
    [InlineData("Roberto", "757383", "7493783218")]
    public void notListContact(string name, string landline, string cellphone)
    {
        Contact contact = new Contact(name, landline, cellphone);
        Directory directory3 = new Directory(2);
        bool result = directory3.listContacts();
        Assert.Equal(false, result);
    }

    [Theory]
    [InlineData("Alfonso", "754937", "3146095976")]
    [InlineData("Roberto", "757383", "7493783218")]
    public void listContact(string name, string landline, string cellphone)
    {
        Contact contact = new Contact(name, landline, cellphone);
        Directory directory = new Directory(2);
        directory.addContact(contact);
        bool result = directory.listContacts();
        Assert.Equal(true, result);
    }

    [Theory]
    [InlineData("Alfonso", "754937", "3146095976")]
    public void findContact(string name, string landline, string cellphone)
    {
        Contact contact = new Contact(name, landline, cellphone);
        Directory directory = new Directory(2);
        directory.addContact(contact);
        bool result = directory.findContact(name);
        Assert.Equal(true, result);
    }

    [Theory]
    [InlineData("Alfonso", "754937", "3146095976")]
    public void notFindContact(string name, string landline, string cellphone)
    {
        Contact contact = new Contact(name, landline, cellphone);
        Directory directory = new Directory(2);
        directory.addContact(contact);
        bool result = directory.findContact("Pacho");
        Assert.Equal(false, result);
    }

    [Theory]
    [InlineData("Alfonso", "754937", "3146095976")]
    public void deleteContact(string name, string landline, string cellphone)
    {
        Contact contact = new Contact(name, landline, cellphone);
        Directory directory = new Directory(2);
        directory.addContact(contact);
        bool result = directory.deleteContact(contact);
        Assert.Equal(true, result);
    }

    [Theory]
    [InlineData("pepina", "754937", "3146095976")]
    public void notDeleteContact(string name, string landline, string cellphone)
    {
        Contact contact = new Contact(name, landline, cellphone);
        Directory directory2 = new Directory(2);
        bool result = directory2.deleteContact(contact);
        Assert.Equal(false, result);
    }

    [Theory]
    [InlineData("Alfonso", "754937", "3146095976")]
    public void notFullDirectoryContact(string name, string landline, string cellphone)
    {
        Contact contact = new Contact(name, landline, cellphone);
        Directory directory = new Directory(2);
        directory.addContact(contact);
        bool result = directory.fullDirectory();
        Assert.Equal(false, result);
    }

    [Fact]
    public void fullDirectoryContact()
    {
        Contact contact = new Contact("Alfonso", "754937", "3146095976");
        Contact contact2 = new Contact("Rogelio", "75493337", "22254454");
        Directory directory = new Directory(2);
        directory.addContact(contact);
        directory.addContact(contact2);
        bool result = directory.fullDirectory();
        Assert.Equal(true, result);
    }

    [Theory]
    [InlineData("Alfonso", "754937", "3146095976")]
    public void notFreeSpaces(string name, string landline, string cellphone)
    {
        Contact contact = new Contact(name, landline, cellphone);
        Directory directory = new Directory(1);
        directory.addContact(contact);
        byte result = directory.freeSpaces();
        Assert.Equal(0, result);
    }
    [Theory]
    [InlineData("Alfonso", "754937", "3146095976")]
    public void freeSpaces(string name, string landline, string cellphone)
    {
        Contact contact = new Contact(name, landline, cellphone);
        Directory directory = new Directory(8);
        directory.addContact(contact);
        byte result = directory.freeSpaces();
        Assert.Equal(7, result);
    }

}