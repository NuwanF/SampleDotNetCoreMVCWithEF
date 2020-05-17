using SampleDotNetCoreMVCWithEF.Models;
using SampleDotNetCoreMVCWithEF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDotNetCoreMVCWithEF.BusinessLogic
{
    public class CustomerManager
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerManager(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task CreateAsync(Customer customer)
        {
            await _customerRepository.CreateAsync(customer);
        }

        public async Task UpdateAsync(Customer customer)
        {
            await _customerRepository.UpdateAsync(customer);
        }

        public async Task DeleteAsync(Customer customer)
        {
            await _customerRepository.DeleteAsync(customer);
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _customerRepository.GetAll();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _customerRepository.GetById(id);
        }
    }
}
