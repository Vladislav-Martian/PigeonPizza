using PigeonPizza.Contexts;
using PigeonPizza.Models.Orders;
using PigeonPizza.Models.Primitive;
using System.Collections.Generic;
using System.Linq;

namespace PigeonPizza.Services
{
    public class ComplexModelUploadingService
    {
        #region Inject
        public AppDbContext _context { get; set; }

        public ComplexModelUploadingService(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Uploaders
        public PizzaOrder Upload(PizzaOrder item)
        {
            return new PizzaOrder()
            {
                Size = Upload(item.Size),
                Dough = Upload(item.Dough),
            };
        }
        public PizzaSize Upload(PizzaSize item)
        {
            PizzaSize ent = _context.PizzaSizes
                .FirstOrDefault(x => x.Name == item.Name);

            if (ent == null)
            {
                ent = _context.PizzaSizes.Add(item).Entity;
                _context.SaveChanges();
            }
                
            return ent;
        }
        public PizzaDough Upload(PizzaDough item)
        {
            PizzaDough ent = _context.PizzaDoughs
                .FirstOrDefault(x => x.Name == item.Name);

            if (ent == null)
            {
                ent = _context.PizzaDoughs.Add(item).Entity;
                _context.SaveChanges();
            }

            return ent;
        }
        public ICollection<PizzaProcessOrder> Upload(ICollection<PizzaProcessOrder> items)
        {
            var updated = new List<PizzaProcessOrder>();
            foreach (var item in items)
            {
                var upd = Upload(item);
                updated.Add(upd);
            }
            return updated;
        }
        public PizzaProcessOrder Upload(PizzaProcessOrder item)
        {
            // TODO
            return item;
        }
        #endregion
    }
}
