using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduceSupplierController : ControllerBase
    {
        private readonly MyDbContext _context;
        public ProduceSupplierController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/<ProduceSupplierController>
        [HttpGet]
        public ActionResult<List<ProduceSupplier>> Get()
        {
            return _context.ProduceSuppliers.ToList();
        }

        // GET api/<ProduceSupplierController>/5
        [HttpGet]
        [Route("{produceID}/{supplierID}")]
        public ActionResult<ProduceSupplier> Get(int produceID, int supplierID)
        {
            ProduceSupplierRepository produceSupplierRepository = new(_context);
            (string message, ProduceSupplier? result) = produceSupplierRepository.FindByID(produceID, supplierID);

            if(message == null)
            {
                return result;
            }
            return NotFound(message);
        }

        // POST api/<ProduceSupplierController>
        [HttpPost]
        public ActionResult<List<ProduceSupplier>> Post(ProduceSupplier value)
        {
            ProduceSupplierRepository produceSupplierRepository = new(_context);
            var result = produceSupplierRepository.AddProduceSupplier(value);

            if(result == "")
            {
                return _context.ProduceSuppliers.ToList();
            }

            return NotFound(result);

        }

        // PUT api/<ProduceSupplierController>/5
        [HttpPut]
        public ActionResult<List<ProduceSupplier>> Put(ProduceSupplier value)
        {
            ProduceSupplierRepository produceSupplierRepository = new(_context);
            var result = produceSupplierRepository.EditProduceSupplier(value);

            if (result == "")
            {
                return _context.ProduceSuppliers.ToList();
            }

            return NotFound(result);

        }

        // DELETE api/<ProduceSupplierController>/5
        [HttpDelete]
        [Route("{produceID}/{supplierID}")]
        public ActionResult<List<ProduceSupplier>> Delete(int produceID, int supplierID)
        {
            ProduceSupplierRepository produceSupplierRepository = new(_context);
            var result = produceSupplierRepository.DeleteProduceSupplier(produceID, supplierID);

            if (result == "")
            {
                return _context.ProduceSuppliers.ToList();
            }

            return NotFound(result);
        }
    }
}
