using AddressBookSystem;
using System.Collections.Generic;
using System;
using System.Threading.Channels;

public class Program
{
    static string file_path = @"E:\BridgeLabz\AddressBookSystem\AddressBookSystem\AddressBookSystem\AddressBookData.json";
    static string txt_path  = @"E:\BridgeLabz\AddressBookSystem\AddressBookSystem\AddressBookSystem\AddressBookFile.txt";
    static void Main(string[] args)
    {
        bool flag = true;string input = null,key=null ;
        AddressBook addressbook = new AddressBook();
        while(flag)
        {
            Console.WriteLine("Enter the option to be proceded : \n1. Create Contact \n2. AddAddressBookToDictionary \n3. Edit Contact \n4. Display \n5. DeleteContact \n6. Dict to Json\n7. Search using 'State'_Dict\n8. Search Using 'City'_Dict \n9. Number of contacts in state \n10. Number of contacts in City\n11. AddToCity,StateDictionary \n12. Sorting the entries\n13. Exit");
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
                    addressbook.WriteToJsonFile(file_path);
                    break;  
                case 7:
                    Console.WriteLine("Enter  'state_name' ,In words :-");
                    string state = Console.ReadLine();
                    addressbook.GetDetailsFromState(state);
                    break;
                case 8:
                    Console.WriteLine("Enter 'City_Name' ,In words :-");
                    string city = Console.ReadLine();
                    addressbook.GetDetailsFromCity(city);
                    break;
                case 9:
                    Console.WriteLine("Enter the State name:");
                    string statename = Console.ReadLine();
                    addressbook.GetContactCountFromState(statename);
                    break;
                case 10:
                    Console.WriteLine("Enter the City name:");
                    string cityname= Console.ReadLine();
                    addressbook.GetContactCountFromCity(cityname);
                    break;
                case 11:
                    addressbook.SearchByCity();
                    addressbook.SearchByState();
                    break;
                case 12:
                    Console.WriteLine("sort using :-");
                    Console.WriteLine("1.Name || 2.State || 3.City");
                    int ch = Convert.ToInt32(Console.ReadLine());
                    addressbook.SortingEntries(ch);
                    break;
                case 13:
                    Console.WriteLine("Enter the input : \n 1.Read from file 2.Write to file");
                    int ch1 = Convert.ToInt32(Console.ReadLine());
                    if (ch1 == 1)
                    {
                        addressbook.ReadFromFile(txt_path);
                    }
                    if (ch1 == 2)
                    {
                        addressbook.WriteToFile(txt_path);
                    }
                    break;
                case 14:
                    flag = false;
                    break;
                default:
                    Console.WriteLine("!! Enter the Correct input !! :");
                    break;


            }
        }

    }
}