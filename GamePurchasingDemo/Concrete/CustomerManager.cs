using GamePurchasingDemo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamePurchasingDemo.Concrete
{
    class CustomerManager
    {
        List<Customer> customers = new List<Customer>();

        public void Add(Customer customer)
        {
            customers.Add(customer);
            Console.WriteLine("You signed up succesfully!");
        }

        public Customer Login(string tcNo)
        {
            bool isLogged = false;
            foreach (var customer in customers)
            {
                if (customer.TcNo == tcNo)
                {
                    Console.WriteLine("You logged in succesfully. Welcome " + customer.Name);
                    isLogged = true;
                    return customer;
                }
            }
            if (!isLogged)
                Console.WriteLine("Cannot find any customers with this TC number. Try to signup.");
            return null;
        }

        public void Update()
        {
            Console.WriteLine("Customer updated succesfully.");
        }
    }
}
