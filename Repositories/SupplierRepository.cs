using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class SupplierRepository
    {
        private readonly MyDbContext _context;
        public SupplierRepository(MyDbContext context)
        {
            _context = context;
        }
        public (string, Supplier?) GetSupplierByID(int id)
        {
            var supplier = _context.Suppliers.Where(x => x.SupplierID == id).FirstOrDefault();
            if (supplier != null)
            {
                return ("", supplier);
            }

            return ("GET failed. Produce ID not found.", supplier);
        }

        public string AddSupplier(Supplier supplier)
        {
            try
            {
                _context.Suppliers.Add(supplier);
                _context.SaveChanges();
                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string EditSupplier(Supplier newSupplier)
        {
            try
            {
                var oldSupplier = _context.Suppliers
                                 .Where(x => x.SupplierID == newSupplier.SupplierID)
                                 .FirstOrDefault();

                if (oldSupplier == null)
                {
                    return "Edit Failed. ID not found.";
                }

                oldSupplier.SupplierName = newSupplier.SupplierName;
                _context.SaveChanges();
                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string DeleteSupplier(int id)
        {
            ProduceSupplierRepository produceSupplierRepository = new(_context);
            try
            {
                var supplier = _context.Suppliers
                              .Where(x => x.SupplierID == id)
                              .FirstOrDefault();

                if (supplier != null)
                {
                    produceSupplierRepository.DeleteProduceSupplierBySupplierID(id);
                    _context.Suppliers.Remove(supplier);
                    _context.SaveChanges();
                    return "";
                }

                return "Delete Failed. ID not found.";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
