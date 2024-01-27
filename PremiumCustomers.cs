using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaFilmow
{
    internal class PremiumCustomers : Customers
    {
        public string subscriptionType;
        public DateOnly subscriptionDuration;

        public static List<Customers> getPremiumCustomers()
        {
            List<Customers> customersList = new List<Customers>();
            string[] lines = File.ReadAllLines("./data/premiumClientInfo.txt");

            foreach (string line in lines)
            {
                string[] data = line.Split(',');

                PremiumCustomers customer = new PremiumCustomers
                {
                    name = data[0].Trim(),
                    surname = data[1].Trim(),
                    address = data[2].Trim(),
                    phoneNumber = int.Parse(data[3].Trim()),
                    emailAddress = data[4].Trim(),
                    dateOfBirth = int.Parse(data[5].Trim()),
                    subscriptionType = data[6].Trim(),
                    subscriptionDuration = DateOnly.Parse(data[7].Trim())
                };

                customersList.Add(customer);
            }

            return customersList;
        }

        public void getAllPremiumCustomers()
        {
            foreach (PremiumCustomers customer in getPremiumCustomers())
                Console.WriteLine(customer.name + " " + customer.surname + " " + customer.subscriptionType + " " + customer.subscriptionDuration);
        }
    }
}
