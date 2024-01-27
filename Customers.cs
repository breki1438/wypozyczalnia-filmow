using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaFilmow
{
    public class Customers
    {
        public string name;
        public string surname;
        public string address;
        public int phoneNumber;
        public string emailAddress;
        public int dateOfBirth;

        public static List<Customers> getCustomers()
        {
            List<Customers> customersList = new List<Customers>();
            string[] lines = File.ReadAllLines("./data/clientInfo.txt");

            foreach (string line in lines)
            {
                string[] data = line.Split(',');

                Customers customer = new Customers
                {
                    name = data[0].Trim(),
                    surname = data[1].Trim(),
                    address = data[2].Trim(),
                    phoneNumber = int.Parse(data[3].Trim()),
                    emailAddress = data[4].Trim(),
                    dateOfBirth = int.Parse(data[5].Trim())
                };

                customersList.Add(customer);
            }

            return customersList;
        }

        public void getAllCustomers()
        {
            foreach (Customers customer in getCustomers())
                Console.WriteLine(customer.name + " " + customer.surname + " " + customer.address + " " + customer.phoneNumber + " " + customer.emailAddress + " " + customer.dateOfBirth);
        }

        public void getCustomer(string name, string surname)
        {
            foreach (Customers customer in getCustomers())
                if (customer.name == name && customer.surname == surname)
                    Console.WriteLine(customer.name + " " + customer.surname + " " + customer.address + " " + customer.phoneNumber + " " + customer.emailAddress + " " + customer.dateOfBirth);
        }
    }
}
