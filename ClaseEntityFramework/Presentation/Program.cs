using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new CustomerServices();

            var customers = services.GetAll();

            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Address}");
            }

            Console.ReadLine();
        }
    }
}
