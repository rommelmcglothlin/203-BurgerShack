using System;
using System.Collections.Generic;
using System.Linq;
using BurgerShack.Data;
using BurgerShack.Models;

namespace BurgerShack.Services
{
  public class OrdersService
  {
    private readonly FakeDb _repo;

    public List<Order> GetOrders()
    {
      return _repo.Orders;
    }

    public List<Order> GetOutstandingOrders()
    {
      return _repo.Orders.Where(o => o.OrderOut == null && !o.Canceled).ToList();
    }

    public List<Order> GetCanceledOrders()
    {
      return _repo.Orders.Where(o => o.Canceled).ToList();
    }

    public OrdersService(FakeDb repo)
    {
      _repo = repo;
    }

    internal Order GetOrderById(string id)
    {
      var order = _repo.Orders.Find(o => o.Id == id);
      if (order == null)
      {
        throw new Exception("Invalid Order Id");
      }
      return order;
    }

    internal Order AddOrder(Order orderData)
    {
      orderData.Id = Guid.NewGuid().ToString();
      orderData.OrderIn = DateTime.Now;

      orderData.Food.ForEach(item =>
      {
        switch (item.Type)
        {
          case "burger":
            var burger = _repo.Burgers.Find(b => b.Id == item.Id);
            if (burger == null) { throw new Exception("Unable to process the order invalid menu option"); }
            item.Price = burger.Price;
            break;
          case "side":
            var side = _repo.Sides.Find(b => b.Id == item.Id);
            if (side == null) { throw new Exception("Unable to process the order invalid menu option"); }
            item.Price = side.Price;
            break;
          case "drink":
            var drink = _repo.Drinks.Find(b => b.Id == item.Id);
            if (drink == null) { throw new Exception("Unable to process the order invalid menu option"); }
            item.Price = drink.Price;
            break;
          default:
            throw new Exception("Invalid Menu Type");
        }

      });

      _repo.Orders.Add(orderData);
      return orderData;
    }

    internal Order CancelOrder(string id)
    {
      var order = GetOrderById(id);
      if (order.OrderOut != null)
      {
        throw new Exception("Order cannot be canceled after it was fullfilled");
      }
      order.Canceled = true;
      return order;
    }

    internal Order FulfillOrder(string id)
    {
      var order = GetOrderById(id);

      if (order.Canceled)
      {
        throw new Exception("Order cannot be fulfilled after it was canceled");
      }

      if (order.OrderOut != null)
      {
        throw new Exception("Order already fulfilled");
      }

      order.OrderOut = DateTime.Now;
      return order;
    }
  }
}