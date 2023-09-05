using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CsvHelper;

namespace AddressBookSystem
{
    public class AddressBook
    {
        List<Contact> addressBook = new List<Contact>();
        Dictionary<string, List<Contact>> dict = new Dictionary<string, List<Contact>>();
        Dictionary<string, List<Contact>> cityDict = new Dictionary<string, List<Contact>>();
        Dictionary<string, List<Contact>> stateDict = new Dictionary<string, List<Contact>>();
        int stateCount, cityCount;




        public void CreateContact()
        {
            Console.WriteLine("Enter the details :-\n1.FirstName \n2.LastName\n3.Address\n4.City\n5.State\n6.Zip\n7.PhoneNumber\n8.Email ");
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
            if (CheckName(contact))
            {
                Console.WriteLine("Name is already present");
            }
            else
            {
                Console.WriteLine(contact.FirstName + "\n " + contact.LastName + "\n " + contact.Address + "\n " + contact.City +
                "\n " + contact.State + "\n " + contact.Zip + "\n " + contact.PhoneNumber + "\n " + contact.Email);
                addressBook.Add(contact);
            }
        }
        public void AddAddressBookToDictionary()
        {
            Console.WriteLine("ENter a key ");
            string uniqueName = Console.ReadLine();
            dict.Add(uniqueName, addressBook);
            addressBook = new List<Contact>();
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
                Console.WriteLine(" !! Contact Terminated !!");

            }
        }
    
            
          public void Display()
          {
            foreach(var item in dict)
            {
                Console.WriteLine(item.Key);
                foreach (var data in item.Value)
                {
                    Console.WriteLine(data.FirstName + "\n" + data.LastName + "\n" + data.Address + "\n" + data.City + "\n" + data.State + "\n" + data.Zip +
                        "\n" + data.PhoneNumber + "\n" + data.Email);
                }
            }   
          }
        

        public bool CheckName(Contact contact)
        {
            string name = contact.FirstName;
            foreach (var data in dict)
            {
                foreach (var item in data.Value)
                {
                    if (item.FirstName.Equals(name))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public void SearchByState()
        {
            foreach (var data in dict.Values)
            {
                foreach (var item in data)
                {
                    if (!stateDict.Keys.Equals(item.State) && !stateDict.ContainsKey(item.State))
                    {
                        List<Contact> list = new List<Contact>();
                        list.Add(item);
                        stateDict.Add(item.State, list);
                    }
                    else
                    {
                        foreach (var states in stateDict)
                        {
                            if (states.Key.Equals(item.State))
                            {
                                states.Value.Add(item);
                            }
                        }
                    }

                }
            }
        }

        public void SearchByCity()
        {
            foreach (var data in dict.Values)
            {
                foreach (var item in data)
                {
                    if (!cityDict.Keys.Equals(item.City))
                    {
                        List<Contact> list = new List<Contact>();
                        list.Add(item);
                        cityDict.Add(item.City, list);
                    }
                    else
                    {
                        foreach (var cities in cityDict)
                        {
                            if (cities.Key.Equals(item.City))
                            {
                                cities.Value.Add(item);
                            }
                        }
                    }
                }
            }
        }

        public void GetDetailsFromState(string input)
        {
            stateCount = 0;
            foreach (var data in stateDict)
            {
                if (data.Key.Equals(input))
                {
                    Console.WriteLine("State : " + data.Key);
                    var statelist = stateDict.GetValueOrDefault(data.Key);
                    DisplayList(statelist.ToList());
                    stateCount = statelist.Count;

                }
            }
        }
        public void GetDetailsFromCity(string input)
        {
            cityCount = 0;
            foreach (var data in cityDict)
            {
                if (data.Key.Equals(input))
                {
                    Console.WriteLine("City : " + data.Key);
                    var citylist = cityDict.GetValueOrDefault(data.Key);
                    DisplayList(citylist.ToList());
                    cityCount = citylist.Count;
                }
            }

        }

        public void GetContactCountFromState(string input)
        {
            GetDetailsFromState(input);
            Console.WriteLine("Count is :- " + stateCount);
        }
        public void GetContactCountFromCity(string input)
        {
            GetDetailsFromCity(input);
            Console.WriteLine("Count is :- " + cityCount);
        }

        public void SortingEntries(int input)
        {
            List<string> list = new List<string>();
            List<Contact> contacts = new List<Contact>();
            switch (input)
            {
                case 1:
                    foreach (var data in dict)
                    {
                        foreach (var item in data.Value)
                        {
                            list.Add(item.FirstName);
                            contacts.Add(item);
                        }
                    }
                    list.Sort();
                    foreach (var data in list)
                    {
                        foreach (var contact in contacts)
                        {
                            if (contact.FirstName.Equals(data))
                            {
                                Console.WriteLine(contact.FirstName + "\n" + contact.LastName + "\n" + contact.Address + "\n" + contact.City + "\n" + contact.State + "\n" + contact.Zip + "\n" + contact.PhoneNumber + "\n" + contact.Email);
                            }
                        }
                    }
                    break;
                case 2:
                    foreach (var data in dict)
                    {
                        foreach (var item in data.Value)
                        {
                            list.Add(item.State);
                            contacts.Add(item);
                        }
                    }
                    list.Sort();
                    foreach (var data in list)
                    {
                        foreach (var contact in contacts)
                        {
                            if (contact.State.Equals(data))
                            {
                                Console.WriteLine(contact.FirstName + "\n" + contact.LastName + "\n" + contact.Address + "\n" + contact.City + "\n" + contact.State + "\n" + contact.Zip + "\n" + contact.PhoneNumber + "\n" + contact.Email);
                            }
                        }
                    }
                    break;
                case 3:
                    foreach (var data in dict)
                    {
                        foreach (var item in data.Value)
                        {
                            list.Add(item.City);
                            contacts.Add(item);
                        }
                    }
                    list.Sort();
                    foreach (var data in list)
                    {
                        foreach (var contact in contacts)
                        {
                            if (contact.City.Equals(data))
                            {
                                Console.WriteLine(contact.FirstName + "\n" + contact.LastName + "\n" + contact.Address + "\n" + contact.City + "\n" + contact.State + "\n" + contact.Zip + "\n" + contact.PhoneNumber + "\n" + contact.Email);
                                Console.WriteLine("**__**");
                            }
                        }
                    }
                    break;
                default:
                    Console.WriteLine(" Enter the correct number !!");
                    return;
            }
        }

        public void DisplayDict(Dictionary<string, List<Contact>> dict)
        {
            foreach (var data in dict)
            {
                Console.WriteLine("Key : " + data.Key);
                foreach (var contact in data.Value)
                {
                    Console.WriteLine(contact.FirstName + "\n" + contact.LastName + "\n" + contact.Address + "\n" + contact.City + "\n" + contact.State + "\n" + contact.Zip + "\n" + contact.PhoneNumber + "\n" + contact.Email);
                }
            }
        }

        public void DisplayList(List<Contact> list)
        {
            foreach (var contact in list)
            {
                Console.WriteLine(contact.FirstName + "\n" + contact.LastName + "\n" + contact.Address + "\n" + contact.City + "\n" + contact.State + "\n" + contact.Zip + "\n" + contact.PhoneNumber + "\n" + contact.Email);
            }
        }

        public void WriteToFile(string filepath)
        {
            using (StreamWriter stream = File.AppendText(filepath))
            {
                foreach (var data in dict)
                {
                    stream.WriteLine(data.Key);
                    foreach (var contact in data.Value)
                    {
                        stream.WriteLine(contact.FirstName + "\n" + contact.LastName + "\n" + contact.Address + "\n" + contact.City + "\n" + contact.State + "\n" + contact.Zip + "\n" + contact.PhoneNumber
                            + "\n" + contact.Email);
                    }
                }
                stream.Close();
            }
        }
        public void ReadFromFile(string filepath)
        {
            using (StreamReader stream = File.OpenText(filepath))
            {
                string set = "";
                while ((set = stream.ReadLine()) != null)
                {
                    Console.WriteLine(set);
                }
            }
        }
        public void ExportToCsv(string filepath)
        {
            using (var writer = new StreamWriter(filepath))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    foreach (var data in dict)
                    {
                        csv.WriteField(data.Key);
                        csv.WriteField("");

                        foreach (var contact in data.Value)
                        {
                            csv.WriteField(contact.FirstName);
                            csv.WriteField(contact.LastName);
                            csv.WriteField(contact.Address);
                            csv.WriteField(contact.City);
                            csv.WriteField(contact.State);
                            csv.WriteField(contact.Zip);
                            csv.WriteField(contact.PhoneNumber);
                            csv.WriteField(contact.Email);

                            csv.WriteField("||");
                        }

                        csv.NextRecord();
                    }
                }
            }
        }


        public void WriteToJsonFile(string filepath)
        {
            var json = JsonConvert.SerializeObject(dict);
            File.WriteAllText(filepath, json);
        }
        public void ReadFromJsonFile(string filepath)
        {
            var json = File.ReadAllText(filepath);
            dict = JsonConvert.DeserializeObject<Dictionary<string, List<Contact>>>(json);
            DisplayDict(dict);
        }
    }
    
}
