using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleDotNetCoreMVCWithEF.BusinessLogic;
using SampleDotNetCoreMVCWithEF.Data;
using SampleDotNetCoreMVCWithEF.Models;

namespace SampleDotNetCoreMVCWithEF.Controllers
{
    public class CustomerController : Controller
    {
        //private readonly CustomerDBContext _context;
        private readonly CustomerManager _customerManager;

        public CustomerController(CustomerManager customerManager)
        {
            //_context = context;
            _customerManager = customerManager;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            return View(await _customerManager.GetAll());
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerManager.GetById((int)id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customer/Create
        public async Task<IActionResult> AddOrEdit(int id=0)
        {
            if (id == 0)
            {
                return View(new Customer());
            }
            else
            {
                var customer = await _customerManager.GetById(id);
                return View(customer);
            }
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("CustomerId,Name,Address,Email,Mobile")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.CustomerId == 0)
                {
                    await _customerManager.CreateAsync(customer);
                }
                else
                {
                    await _customerManager.UpdateAsync(customer);
                }
                
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerManager.GetById((int)id);
            if (customer == null)
            {
                return NotFound();
            }

            await _customerManager.DeleteAsync(customer);
            return RedirectToAction(nameof(Index));
        }

    }
}
