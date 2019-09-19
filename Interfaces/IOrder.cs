using System;
using System.Collections.Generic;
using BurgerShack.Models;

namespace BurgerShack.Interfaces
{
    public interface IOrder
    {
        string Id { get; set; }
        string Name { get; set; }
        bool Canceled { get; set; }
        List<Item> Food { get; set; }
        DateTime OrderIn { get; set; }
        DateTime? OrderOut { get; set; }

    }
}