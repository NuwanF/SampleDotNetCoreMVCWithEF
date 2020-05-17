using Microsoft.EntityFrameworkCore;
using SampleDotNetCoreMVCWithEF.Data;
using SampleDotNetCoreMVCWithEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDotNetCoreMVCWithEF.Repository
{
    public class CustomerRepository
    {
        private readonly CustomerDBContext _context;

        public CustomerRepository(CustomerDBContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Customer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Customer customer)
        {
            _context.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
        }
    }
}
