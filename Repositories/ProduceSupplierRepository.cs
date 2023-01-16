using WebApplication1.Models;
namespace WebApplication1.Repositories
{
    public class ProduceSupplierRepository
    {
        private readonly MyDbContext _context;
        public ProduceSupplierRepository(MyDbContext context)
        {
            _context = context;
        }

        public (string, ProduceSupplier?) FindByID(int produceID, int supplierID)
        {
            var produceSupplier = _context.ProduceSuppliers
                                  .Where(x => x.ProduceID == produceID)
                                  .Where(y => y.SupplierID == supplierID)
                                  .FirstOrDefault();
            if (produceSupplier != null)
            {
                return ("", produceSupplier);
            }

            return ("GET failed. ID not found.", produceSupplier);
        }

        public string AddProduceSupplier(ProduceSupplier value)
        {
            try
            {
                string validate = ValidateID(value.ProduceID, value.SupplierID);

                if (validate != "")
                {
                    return validate;
                }

                _context.ProduceSuppliers.Add(value);
                _context.SaveChanges();
                return "";

            }
            catch (Exception e)
            {
                return e.InnerException.Message;
            }
        }

        public string EditProduceSupplier(ProduceSupplier value)
        {
            ProduceRepository produceRepository = new(_context);
            SupplierRepository supplierRepository = new(_context);

            try
            {
                string validate = ValidateID(value.ProduceID, value.SupplierID);

                if (validate != "")
                {
                    return validate;
                }

                var produceSupplier = _context.ProduceSuppliers
                                      .Where(x => x.SupplierID == value.SupplierID)
                                      .Where(y => y.ProduceID == value.ProduceID)
                                      .FirstOrDefault();

                produceSupplier.Qty = value.Qty;
                _context.SaveChanges();
                return "";

            }
            catch (Exception e)
            {
                return e.InnerException.Message;
            }
        }

        public string DeleteProduceSupplier(int produceID, int supplierID)
        {
            try
            {
                string validate = ValidateID(produceID, supplierID);

                if(validate != "")
                {
                    return validate;
                }

                var produceSupplier = _context.ProduceSuppliers
                                      .Where(x => x.SupplierID == supplierID)
                                      .Where(y => y.ProduceID == produceID)
                                      .FirstOrDefault();

                _context.ProduceSuppliers.Remove(produceSupplier);
                _context.SaveChanges();
                return "";

            }
            catch (Exception e)
            {
                return e.InnerException.Message;
            }
        }

        public string ValidateID(int produceID, int supplierID)
        {
            ProduceRepository produceRepository = new(_context);
            SupplierRepository supplierRepository = new(_context);

            try
            {
                var produce = produceRepository.GetProduceByID(produceID);
                var supplier = supplierRepository.GetSupplierByID(supplierID);

                if (produce.Item2 == null)
                {
                    return produce.Item1;
                }
                else if (supplier.Item2 == null)
                {
                    return supplier.Item1;
                }

                return "";

            }
            catch (Exception e)
            {
                return e.InnerException.Message;
            }

        }

        public void DeleteProduceSupplierByProduceID(int produceID)
        {
            List<ProduceSupplier> results = _context.ProduceSuppliers
                                            .Where(x => x.ProduceID == produceID)
                                            .ToList();
                                            
            foreach(var produceSupplier in results)
            {
                _context.ProduceSuppliers.Remove(produceSupplier);
            }
            _context.SaveChanges();
        }

        public void DeleteProduceSupplierBySupplierID(int supplierID)
        {
            List<ProduceSupplier> results = _context.ProduceSuppliers
                                            .Where(x => x.SupplierID == supplierID)
                                            .ToList();

            foreach (var produceSupplier in results)
            {
                _context.ProduceSuppliers.Remove(produceSupplier);
            }
            _context.SaveChanges();
        }
    }
}
