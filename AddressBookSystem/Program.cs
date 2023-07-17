using AddressBookSystem;
using System;

internal class Program
{
     static void Main(string[] args)
    {
        Console.WriteLine("Enter the option to be proceded : \n1.Create Contact \n2.Edit Contact \n3.Display \n4.DeleteContact \n5.Exit");
        bool flag = true;
        AddressBook addressbook = new AddressBook();
        while(flag)
        {
            int option = Convert.ToInt32(Console.ReadLine());
            switch(option)
            {
                case 1:
                    Console.WriteLine("Give the name to Create Contact Details :-");
                    string input = Console.ReadLine();
                    addressbook.CreateContact();
                    break;
                case 2:
                    Console.WriteLine("Enter name To edit Contact Details :-");
                    string input1 = Console.ReadLine();
                    addressbook.EditContact(input1);
                    break;
                case 3:
                    addressbook.Display();
                    break;
                case 4:
                    Console.WriteLine("Enter name of Contact to delete :-");
                    string input2 = Console.ReadLine();
                    addressbook.DeleteContact(input2);
                    break;
                case 5:
                    flag = false;
                    break;

            }
        }

    }
}