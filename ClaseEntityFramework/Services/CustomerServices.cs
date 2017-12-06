using DataAccess;
using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerServices
    {
        private Repository<Customer> _customerRepository;

        public CustomerServices()
        {
            _customerRepository = new Repository<Customer>();
        }

        public IEnumerable<CustomerDto> GetAll()
        {
            return _customerRepository.Set()
                .ToList()
                .Select(c => new CustomerDto
                {
                    Address = c.Address,
                    CustomerID = c.CustomerID,
                    CompanyName = c.CompanyName,
                    ContactName = c.ContactName

                });
        }

        public void Create(CustomerDto dto)
        {
            _customerRepository.Persist(new Customer
            {
                Address = dto.Address,
                City = dto.City,
                CompanyName = dto.CompanyName,
                ContactName = dto.ContactName,
                ContactTitle = dto.ContactTitle,
                Country = dto.Country,
                CustomerID = dto.CustomerID,
                Region = dto.Region,
                PostalCode = dto.PostalCode,
                Phone = dto.Phone,
                Fax = dto.Fax,
            });

            _customerRepository.SaveChanges();
        }

        public void Update(CustomerDto dto)
        {
            var customer = _customerRepository.Set()
                .FirstOrDefault(x => x.CustomerID == dto.CustomerID);

            if (customer == null)
                throw new Exception("El cliente no existe");

            customer.Address = dto.Address;
            customer.City = dto.City;
            customer.CompanyName = dto.CompanyName;
            customer.ContactName = dto.ContactName;
            customer.ContactTitle = dto.ContactTitle;
            customer.Country = dto.Country;
            customer.Region = dto.Region;
            customer.PostalCode = dto.PostalCode;
            customer.Phone = dto.Phone;
            customer.Fax = dto.Fax;

            _customerRepository.Update(customer);
            _customerRepository.SaveChanges();
        }

        public void Remove(CustomerDto dto)
        {
            var customer = _customerRepository.Set()
                .FirstOrDefault(x => x.CustomerID == dto.CustomerID);

            if (customer == null)
            {
                throw new Exception("El cliente no existe");
            }
                
            
            _customerRepository.Remove(customer);
            _customerRepository.SaveChanges();
        }
    }
}
