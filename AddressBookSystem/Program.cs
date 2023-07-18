using AddressBookSystem;
using System;
using System.Threading.Channels;

internal class Program
{
     static void Main(string[] args)
    {
        bool flag = true;string input = null,key=null ;
        AddressBook addressbook = new AddressBook();
        while(flag)
        {
            Console.WriteLine("Enter the option to be proceded : \n1. Create Contact \n2. AddAddressBookToDictionary \n3.Edit Contact \n4. Display \n5. DeleteContact \n6. Exit");
            int option = Convert.ToInt32(Console.ReadLine());
            switch(option)
            {
                case 1:
                    Console.WriteLine("Give the name to Create Contact Details :-");
                    Console.ReadLine();
                    addressbook.CreateContact();
                    break;
                case 2:
                    addressbook.AddAddressBookToDictionary();

                    break;

                case 3:
                    Console.WriteLine("Enter name To edit Contact Details :-");
                    key= Console.ReadLine();
                    addressbook.EditContact(key,input);
                    break;
                case 4:
                    addressbook.Display();
                    break;
                case 5:
                    Console.WriteLine("Enter Key :-");
                    key = Console.ReadLine();
                    Console.WriteLine("Enter name of Contact to delete :-");
                    input = Console.ReadLine();
                    addressbook.DeleteContact(key,input);
                    break;
                case 6:
                    flag = false;
                    break;

            }
        }

    }
}