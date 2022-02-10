using FluentValidation.Results;
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
        ContactValidator contactValidator = new ContactValidator(directory.getQuery());
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
        ContactValidator contactValidator = new ContactValidator(directory.getQuery());
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
        ContactValidator contactValidator = new ContactValidator(directory.getQuery());
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
        ContactValidator contactValidator = new ContactValidator(directory.getQuery());
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
        ContactValidator contactValidator = new ContactValidator(directory.getQuery());
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
        ContactValidator contactValidator = new ContactValidator(directory2.getQuery());
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

    [Fact]
    public void nameContacIsEmpty()
    {
        nameValidationMultiuseClass contactValidation = new nameValidationMultiuseClass();
        Contact contact = new Contact("");
        ValidationResult validationResult = contactValidation.Validate(contact);
        Assert.False(validationResult.IsValid);
    }
    [Fact]
    public void nameContacIsNumber()
    {
        nameValidationMultiuseClass contactValidation = new nameValidationMultiuseClass();
        Contact contact = new Contact("32");
        ValidationResult validationResult = contactValidation.Validate(contact);
        Assert.False(validationResult.IsValid);
    }
    [Fact]
    public void nameContacOver50()
    {
        nameValidationMultiuseClass contactValidation = new nameValidationMultiuseClass();
        Contact contact = new Contact("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum");
        ValidationResult validationResult = contactValidation.Validate(contact);
        Assert.False(validationResult.IsValid);
    }
    [Fact]
    public void nameContacIsCorrect()
    {
        nameValidationMultiuseClass contactValidation = new nameValidationMultiuseClass();
        Contact contact = new Contact("Cristian Andres Cruz Suazo");
        ValidationResult validationResult = contactValidation.Validate(contact);
        Assert.True(validationResult.IsValid);
    }

    [Fact]
    public void nameContacAlreadyExist()
    {
        Directory directory = new Directory(2);
        nameValidationClass contactValidation = new nameValidationClass(directory.getQuery());
        Contact contact = new Contact("pedro", "3231545312", "3105235476");
        Contact contact2 = new Contact("pedro", "3454534534", "3242342342");
        directory.addContact(contact);
        ValidationResult validationResult = contactValidation.Validate(contact2);
        Assert.False(validationResult.IsValid);
    }

    [Fact]
    public void landlineContacIsEmpty()
    {
        landlineValidationClass contactValidation = new landlineValidationClass();
        Contact contact = new Contact("pedro", "", "3105235476");
        ValidationResult validationResult = contactValidation.Validate(contact);
        Assert.False(validationResult.IsValid);
    }
    [Fact]
    public void landlineContacIsLetter()
    {
        landlineValidationClass contactValidation = new landlineValidationClass();
        Contact contact = new Contact("pedro", "number", "3105235476");
        ValidationResult validationResult = contactValidation.Validate(contact);
        Assert.False(validationResult.IsValid);
    }
    [Fact]
    public void landlineContacOver15()
    {
        landlineValidationClass contactValidation = new landlineValidationClass();
        Contact contact = new Contact("pedro", "123456789101112131415", "3105234455");
        ValidationResult validationResult = contactValidation.Validate(contact);
        Assert.False(validationResult.IsValid);
    }
    [Fact]
    public void landlineContacIsCorrect()
    {
        landlineValidationClass contactValidation = new landlineValidationClass();
        Contact contact = new Contact("pedro", "123456789", "3105234455");
        ValidationResult validationResult = contactValidation.Validate(contact);
        Assert.True(validationResult.IsValid);
    }

    [Fact]
    public void cellphoneContacIsEmpty()
    {
        cellphoneValidationClass contactValidation = new cellphoneValidationClass();
        Contact contact = new Contact("pedro", "3105235476", "");
        ValidationResult validationResult = contactValidation.Validate(contact);
        Assert.False(validationResult.IsValid);
    }
    [Fact]
    public void cellphoneContacIsLetter()
    {
        cellphoneValidationClass contactValidation = new cellphoneValidationClass();
        Contact contact = new Contact("pedro", "3105235476", "number");
        ValidationResult validationResult = contactValidation.Validate(contact);
        Assert.False(validationResult.IsValid);
    }
    [Fact]
    public void cellphoneContacOver15()
    {
        cellphoneValidationClass contactValidation = new cellphoneValidationClass();
        Contact contact = new Contact("pedro", "3105234455", "123456789101112131415");
        ValidationResult validationResult = contactValidation.Validate(contact);
        Assert.False(validationResult.IsValid);
    }
    [Fact]
    public void cellphoneContacIsCorrect()
    {
        cellphoneValidationClass contactValidation = new cellphoneValidationClass();
        Contact contact = new Contact("pedro", "123456789", "3105234455");
        ValidationResult validationResult = contactValidation.Validate(contact);
        Assert.True(validationResult.IsValid);
    }
}