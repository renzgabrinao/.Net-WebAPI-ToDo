using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly MyDbContext _context;
        public SupplierController(MyDbContext context)
        {
            _context = context;
        }
        // GET: api/<SupplierController>
        [HttpGet]
        public ActionResult<List<Supplier>> Get()
        {
            return _context.Suppliers.ToList();
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public ActionResult<Supplier> Get(int id)
        {
            SupplierRepository SupplierRepository = new(_context);
            (string msg, Supplier? supplier) = SupplierRepository.GetSupplierByID(id);

            if (msg == "")
            {
                return supplier;
            }

            return NotFound(msg);
        }

        // POST api/<SupplierController>
        [HttpPost]
        public ActionResult<List<Supplier>> Post(Supplier supplier)
        {
            SupplierRepository SupplierRepository = new(_context);
            var result = SupplierRepository.AddSupplier(supplier);
            if (result == "")
            {
                return _context.Suppliers.ToList();
            }
            return BadRequest(result);
        }

        // PUT api/<SupplierController>/5
        [HttpPut]
        public ActionResult<List<Supplier>> Put(Supplier value)
        {
            SupplierRepository SupplierRepository = new(_context);
            var result = SupplierRepository.EditSupplier(value);

            if (result == "")
            {
                return _context.Suppliers.ToList();
            }
            return NotFound(result);
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public ActionResult<List<Supplier>> Delete(int id)
        {
            SupplierRepository SupplierRepository = new(_context);
            var result = SupplierRepository.DeleteSupplier(id);

            if (result == "")
            {
                return _context.Suppliers.ToList();
            }

            return NotFound(result);
        }
    }
}
