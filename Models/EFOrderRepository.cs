using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace HPStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private HPStoreDbContext context;
        public EFOrderRepository(HPStoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Order> Orders => context.Orders
        .Include(o => o.Lines)
        .ThenInclude(l => l.Tainghe);
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Tainghe));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
