using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace AddressBookSystem
{
    public class AddressBook
    {
        List<Contact> addressBook = new List<Contact>();
        Dictionary<string, List<Contact>> dict = new Dictionary<string, List<Contact>>();
        public void CreateContact()
        {
            Console.WriteLine("Enter the details :\n1.FirstName \n2.LastName\n3.Address\n4.City\n5.State" +
                "\n6.Zip\n7.PhoneNumber\n8.Email ");
            Contact contact = new Contact()
            {
                FirstName = Console.ReadLine(),
                LastName = Console.ReadLine(),
                Address = Console.ReadLine(),
                City = Console.ReadLine(),
                State = Console.ReadLine(),
                Zip = Convert.ToInt32(Console.ReadLine()),
                PhoneNumber = Convert.ToInt32(Console.ReadLine()),
                Email = Console.ReadLine()

            };
            Console.WriteLine(contact.FirstName + "\n " + contact.LastName + "\n " + contact.Address + "\n " + contact.City +
                "\n " + contact.State + "\n " + contact.Zip + "\n " + contact.PhoneNumber + "\n " + contact.Email);
            addressBook.Add(contact);
        }
        public void AddAddressBookToDictionary()
        {
            string uniqueName = Console.ReadLine();
            dict.Add(uniqueName, addressBook);
            addressBook = null;
        }
        public void EditContact(string name, string contactName)
        {
            foreach (var data in dict)
            {
                if (data.Key.Equals(name))
                {
                    foreach (var contact in data.Value)


                    {
                        if (contact.FirstName.Equals(name) || contact.LastName.Equals(name))
                        {
                            Console.WriteLine("Enter The Option To Edit :- \n1.LastName + \n2.Address + \n3.City \n4.State +\n5.Zip +\n6.PhoneNumber +" +
                                "\n7.Email \n8.Exit");
                            int option = Convert.ToInt32(Console.ReadLine());
                            switch (option)
                            {
                                case 1:
                                    contact.LastName = Console.ReadLine();
                                    break;
                                case 2:
                                    contact.Address = Console.ReadLine();
                                    break;
                                case 3:
                                    contact.City = Console.ReadLine();
                                    break;
                                case 4:
                                    contact.State = Console.ReadLine();
                                    break;
                                case 5:
                                    contact.Zip = Convert.ToInt32(Console.ReadLine());
                                    break;
                                case 6:
                                    contact.PhoneNumber = Convert.ToInt32(Console.ReadLine());
                                    break;
                                case 7:
                                    contact.Email = Console.ReadLine();
                                    break;

                            }
                        }
                    }
                }
            }
        }
        public void DeleteContact(string name, string contactName)
        {
            Contact contact = new Contact();
            foreach (var data in dict)
            {
                if (data.Key.Equals(name))
                {
                    foreach (var item in data.Value)
                        if (contact.FirstName.Equals(name) || contact.LastName.Equals(name))
                        {
                            contact = item;
                        }
                }
                data.Value.Remove(contact);

            }
        }

          public void Display()
          {
            foreach(var item in dict)
            {
                Console.WriteLine(item.Key);
                foreach (var data in item.Value)
                {
                    Console.WriteLine(data.FirstName + "\n" + data.LastName + "\n" + data.Address + "n" + data.City + "\n" + data.State + "\n" + data.Zip +
                        "\n" + data.PhoneNumber + "\n" + data.Email);
                }
            }   
          }
    }
}
