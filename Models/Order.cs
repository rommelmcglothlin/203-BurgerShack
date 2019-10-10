using System;
using System.Collections.Generic;
using System.Linq;
using BurgerShack.Interfaces;

namespace BurgerShack.Models
{
  public class Order : IOrder
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public bool Canceled { get; set; }

    public decimal Total { get { return Food.Sum(i => i.Price); } }

    public string UserId { get; set; }

    public List<Item> Food { get; set; }
    public DateTime OrderIn { get; set; }
    public DateTime? OrderOut { get; set; }
    public DateTime? OrderCanceledAt { get; set; }

  }

}