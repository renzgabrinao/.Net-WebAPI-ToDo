using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ProduceRepository
    {
        private readonly MyDbContext _context;
        public ProduceRepository(MyDbContext context)
        {
            _context = context;
        }

        public (string, Produce?) GetProduceByID(int id)
        {
            var produce = _context.Produces.Where(x => x.ProduceID == id).FirstOrDefault();
            if(produce != null)
            {
                return ("", produce);
            }

            return ("GET failed. Produce ID not found.", produce);
        }

        public string AddProduce(Produce produce)
        {
            try
            {
                _context.Produces.Add(produce);
                _context.SaveChanges();
                return "";
            }
            catch (Exception e)
            {
                return e.InnerException.Message;
            }
        }

        public string EditProduce(Produce newProduce)
        {
            try
            {
                var oldProduce = _context.Produces
                                 .Where(x => x.ProduceID == newProduce.ProduceID)
                                 .FirstOrDefault();

                if(oldProduce == null)
                {
                    return "Edit Failed. ID not found.";
                }

                oldProduce.Description = newProduce.Description;
                _context.SaveChanges();
                return "";
            }
            catch (Exception e)
            {
                return e.InnerException.Message;
            }
        }

        public string DeleteProduce(int id)
        {
            ProduceSupplierRepository produceSupplierRepository = new(_context);
            try
            {
                var produce = _context.Produces
                              .Where(x => x.ProduceID == id)
                              .FirstOrDefault();

                if(produce != null)
                {
                    produceSupplierRepository.DeleteProduceSupplierByProduceID(id);
                    _context.Produces.Remove(produce);
                    _context.SaveChanges();
                    return "";
                }

                return "Delete Failed. ID not found.";
            }
            catch (Exception e)
            {
                return e.InnerException.Message;
            }
        }
    }
}
