using AddressBookSystem;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("welcome to address book :-:-");
        AddressBook book = new AddressBook();
        book.CreateContact();

    }
}