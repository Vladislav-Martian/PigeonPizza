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
            var ent = new PizzaOrder()
            {
                Size = Upload(item.Size),
                Dough = Upload(item.Dough),
                Processing = Upload(item.Processing),
                PrimeComplex = Upload(item.PrimeComplex),
                SecondComplex = Upload(item.PrimeComplex),
            };
            _context.PizzaOrders.Add(ent);
            _context.SaveChanges();
            return ent;
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
        // Process
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
            var ent = new PizzaProcessOrder()
            {
                Order = Upload(item.Order),
                Amount = item.Amount,
            };
            ent = _context.PizzaProcessOrders.Add(ent).Entity;
            _context.SaveChanges();
            return ent;
        }
        public PizzaProcess Upload(PizzaProcess item)
        {
            PizzaProcess ent = _context.PizzaProcesses
                .FirstOrDefault(x => x.Name == item.Name);

            if (ent == null)
            {
                ent = _context.PizzaProcesses.Add(item).Entity;
                _context.SaveChanges();
            }

            return ent;
        }
        // Complex
        public PizzaComplexOrder Upload(PizzaComplexOrder item)
        {
            var ent = new PizzaComplexOrder()
            {
                SauceOrder = Upload(item.SauceOrder),
                BaseOrder = Upload(item.BaseOrder),
                ToppingOrder = Upload(item.ToppingOrder),
                SpiceOrder = Upload(item.SpiceOrder),
            };
            ent = _context.PizzaComplexOrders.Add(ent).Entity;
            _context.SaveChanges();
            return ent;
        }
        // SAUCE
        public ICollection<PizzaSauceOrder> Upload(ICollection<PizzaSauceOrder> items)
        {
            var updated = new List<PizzaSauceOrder>();
            foreach (var item in items)
            {
                var upd = Upload(item);
                updated.Add(upd);
            }
            return updated;
        }
        public PizzaSauceOrder Upload(PizzaSauceOrder item)
        {
            var ent = new PizzaSauceOrder()
            {
                Order = Upload(item.Order),
                Amount = item.Amount,
            };
            ent = _context.PizzaSauceOrders.Add(ent).Entity;
            _context.SaveChanges();
            return ent;
        }
        public PizzaSauce Upload(PizzaSauce item)
        {
            PizzaSauce ent = _context.PizzaSauces
                .FirstOrDefault(x => x.Name == item.Name);

            if (ent == null)
            {
                ent = _context.PizzaSauces.Add(item).Entity;
                _context.SaveChanges();
            }

            return ent;
        }
        // BASE
        public ICollection<PizzaBaseOrder> Upload(ICollection<PizzaBaseOrder> items)
        {
            var updated = new List<PizzaBaseOrder>();
            foreach (var item in items)
            {
                var upd = Upload(item);
                updated.Add(upd);
            }
            return updated;
        }
        public PizzaBaseOrder Upload(PizzaBaseOrder item)
        {
            var ent = new PizzaBaseOrder()
            {
                Order = Upload(item.Order),
                Amount = item.Amount,
            };
            ent = _context.PizzaBaseOrders.Add(ent).Entity;
            _context.SaveChanges();
            return ent;
        }
        public PizzaBase Upload(PizzaBase item)
        {
            PizzaBase ent = _context.PizzaBases
                .FirstOrDefault(x => x.Name == item.Name);

            if (ent == null)
            {
                ent = _context.PizzaBases.Add(item).Entity;
                _context.SaveChanges();
            }

            return ent;
        }
        // TOPPING
        public ICollection<PizzaToppingOrder> Upload(ICollection<PizzaToppingOrder> items)
        {
            var updated = new List<PizzaToppingOrder>();
            foreach (var item in items)
            {
                var upd = Upload(item);
                updated.Add(upd);
            }
            return updated;
        }
        public PizzaToppingOrder Upload(PizzaToppingOrder item)
        {
            var ent = new PizzaToppingOrder()
            {
                Order = Upload(item.Order),
                Amount = item.Amount,
            };
            ent = _context.PizzaToppingOrders.Add(ent).Entity;
            _context.SaveChanges();
            return ent;
        }
        public PizzaTopping Upload(PizzaTopping item)
        {
            PizzaTopping ent = _context.PizzaToppings
                .FirstOrDefault(x => x.Name == item.Name);

            if (ent == null)
            {
                ent = _context.PizzaToppings.Add(item).Entity;
                _context.SaveChanges();
            }

            return ent;
        }
        // SPICE
        public ICollection<PizzaSpiceOrder> Upload(ICollection<PizzaSpiceOrder> items)
        {
            var updated = new List<PizzaSpiceOrder>();
            foreach (var item in items)
            {
                var upd = Upload(item);
                updated.Add(upd);
            }
            return updated;
        }
        public PizzaSpiceOrder Upload(PizzaSpiceOrder item)
        {
            var ent = new PizzaSpiceOrder()
            {
                Order = Upload(item.Order),
                Amount = item.Amount,
            };
            ent = _context.PizzaSpiceOrders.Add(ent).Entity;
            _context.SaveChanges();
            return ent;
        }
        public PizzaSpice Upload(PizzaSpice item)
        {
            PizzaSpice ent = _context.PizzaSpices
                .FirstOrDefault(x => x.Name == item.Name);

            if (ent == null)
            {
                ent = _context.PizzaSpices.Add(item).Entity;
                _context.SaveChanges();
            }

            return ent;
        }
        #endregion
    }
}
