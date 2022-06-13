using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPStore.Models
{
    public class MyCart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public virtual void AddItem(Tainghe tainghe, int quantity)
        {
            CartLine line = Lines
            .Where(b => b.Tainghe.TaingheID == tainghe.TaingheID)
            .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Tainghe = tainghe,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Tainghe tainghe) =>
        Lines.RemoveAll(l => l.Tainghe.TaingheID == tainghe.TaingheID);
        public decimal ComputeTotalValue() =>
        Lines.Sum(e => e.Tainghe.Gia * e.Quantity);
        public virtual void Clear() => Lines.Clear();
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Tainghe Tainghe { get; set; }
        public int Quantity { get; set; }
    }
}
