using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AddressBookSystem
{
    internal class AddressBook
    {
        List<Contact> addressBook = new List<Contact>();
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
    }
}
