using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BurgerShack.Data;
using BurgerShack.Models;

namespace BurgerShack.Services
{
  public class OrdersService
  {
    private readonly FakeDb _fakeRepo;
    private IDbConnection _repo;
    private readonly BurgersService _bs;

    public List<Order> GetOrders()
    {
      return _fakeRepo.Orders;
    }

    public List<Order> GetOutstandingOrders()
    {
      return _fakeRepo.Orders.Where(o => o.OrderOut == null && !o.Canceled).ToList();
    }

    public List<Order> GetCanceledOrders()
    {
      return _fakeRepo.Orders.Where(o => o.Canceled).ToList();
    }

    public OrdersService(
      FakeDb fakeRepo,
      IDbConnection repo,
      BurgersService bs)
    {
      _fakeRepo = fakeRepo;
      _repo = repo;
      _bs = bs;
    }

    internal Order GetOrderById(string id)
    {
      var order = _fakeRepo.Orders.Find(o => o.Id == id);
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
            var burger = _bs.GetBurgerById(item.Id);
            item.Price = burger.Price;
            break;
          case "side":
            var side = _fakeRepo.Sides.Find(b => b.Id == item.Id);
            if (side == null) { throw new Exception("Unable to process the order invalid menu option"); }
            item.Price = side.Price;
            break;
          case "drink":
            var drink = _fakeRepo.Drinks.Find(b => b.Id == item.Id);
            if (drink == null) { throw new Exception("Unable to process the order invalid menu option"); }
            item.Price = drink.Price;
            break;
          default:
            throw new Exception("Invalid Menu Type");
        }

      });

      _fakeRepo.Orders.Add(orderData);
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