using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebApplication1.Models;
using WebApplication1.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly TodoContext _context;
        public ToDoController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/<ToDoController>
        [HttpGet]
        public ActionResult<List<ToDo>> Get()
        {
            var todo = _context.ToDos.ToList();
            return todo;
        }

        // GET api/<ToDoController>/5
        [HttpGet("{id}")]
        public ActionResult<ToDo> Get(int id)
        {
            ToDoRepository toDoRepo = new ToDoRepository(_context);
            var todo = toDoRepo.FindById(id); 
            if (todo != null)
            {
                return todo;
            }
            return NotFound("ID Not Found :(");
        }

        // POST api/<ToDoController>
        [HttpPost]
        public ActionResult<List<ToDo>> Post(ToDo value)
        {
            ToDoRepository toDoRepo = new ToDoRepository(_context);
            var response = toDoRepo.AddItem(value);
            if(response == "")
            {
                return (_context.ToDos.ToList());
            }
            return BadRequest(response);
        }

        // PUT api/<ToDoController>/5
        [HttpPut]
        public ActionResult<List<ToDo>> Put(ToDo value)
        {
            ToDoRepository toDoRepo = new ToDoRepository(_context);
            var response = toDoRepo.UpdateItem(value);
            if (response == "")
            {
                return (_context.ToDos.ToList());
            }
            return NotFound(response);
        }

        // DELETE api/<ToDoController>/5
        [HttpDelete("{id}")]
        public ActionResult<List<ToDo>> Delete(int id)
        {
            ToDoRepository toDoRepo = new ToDoRepository(_context);
            var response = toDoRepo.DeleteItem(id);
            if (response == "")
            {
                return (_context.ToDos.ToList());
            }
            return NotFound(response);
        }
    }
}
