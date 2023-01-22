using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ToDoRepository
    {
        private readonly TodoContext _context;
        public ToDoRepository(TodoContext context)
        {
            _context = context;
        }

        public ToDo FindById(int id)
        {
            var todo = _context.ToDos.Find(id);
            return todo;
        }

        public string AddItem(ToDo value)
        {
            try
            {
                _context.ToDos.Add(value);
                _context.SaveChanges();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateItem(ToDo value)
        {
            try
            {
                var item = _context.ToDos.Where(x => x.Id == value.Id).FirstOrDefault();
                if(item != null)
                {
                    item.Description = value.Description;
                    item.Priority = value.Priority;
                    item.IsComplete = value.IsComplete;

                    _context.SaveChanges();
                    return "";
                }
                return "ID not found.";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteItem(int id)
        {
            try
            {
                var todo = _context.ToDos.Where(x => x.Id == id).FirstOrDefault();
                if (todo != null)
                {
                    _context.ToDos.Remove(todo);
                    _context.SaveChanges();
                    return "";
                }
                return "ID not found.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


    }
}
