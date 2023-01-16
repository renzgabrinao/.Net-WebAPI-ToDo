using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduceController : ControllerBase
    {
        private readonly MyDbContext _context;
        public ProduceController(MyDbContext context)
        {
            _context = context;
        }
        // GET: api/<ProduceController>
        [HttpGet]
        public ActionResult<List<Produce>> Get()
        {
            return _context.Produces.ToList();
        }

        // GET api/<ProduceController>/5
        [HttpGet("{id}")]
        public ActionResult<Produce> Get(int id)
        {
            ProduceRepository ProduceRepository = new (_context);
            (string msg, Produce? produce) = ProduceRepository.GetProduceByID(id);

            if(msg == "")
            {
                return produce;
            }

            return NotFound(msg);
        }

        // POST api/<ProduceController>
        [HttpPost]
        public ActionResult<List<Produce>> Post(Produce produce)
        {
            ProduceRepository ProduceRepository = new(_context);
            var result = ProduceRepository.AddProduce(produce);
            if(result == "")
            {
                return _context.Produces.ToList();
            }
            return BadRequest(result);
        }

        // PUT api/<ProduceController>/5
        [HttpPut]
        public ActionResult<List<Produce>> Put(Produce value)
        {
            ProduceRepository ProduceRepository = new(_context);
            var result = ProduceRepository.EditProduce(value);

            if(result == "")
            {
                return _context.Produces.ToList();
            }
            return NotFound(result);
        }

        // DELETE api/<ProduceController>/5
        [HttpDelete("{id}")]
        public ActionResult<List<Produce>> Delete(int id)
        {
            ProduceRepository ProduceRepository = new(_context);
            var result = ProduceRepository.DeleteProduce(id);
            
            if(result == "")
            {
                return _context.Produces.ToList();
            }

            return NotFound(result);
        }
    }
}
