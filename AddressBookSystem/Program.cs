using AddressBookSystem;
using System;

internal class Program
{
     static void Main(string[] args)
    {
        Console.WriteLine("Enter the option to be proceded : \n1.Create Contact \n2.Edit Contact \n3.Exit");
        bool flag = true;
        AddressBook addressbook = new AddressBook();
        while(flag)
        {
            int option = Convert.ToInt32(Console.ReadLine());
            switch(option)
            {
                case 1:
                    addressbook.CreateContact();
                    break;
                case 2:
                    Console.WriteLine("Enter name To edit Contact Details :-");
                    string input = Console.ReadLine();
                    break;
                case 3:
                    flag = false;
                    break;

            }
        }

    }
}