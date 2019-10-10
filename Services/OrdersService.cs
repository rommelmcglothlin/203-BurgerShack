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
    private OrdersRepository _repo;
    private readonly ItemsService _bs;

    public List<Order> GetOrders()
    {
      return _repo.GetAll().ToList();
    }

    public List<Order> GetOutstandingOrders()
    {
      return GetOrders().Where(o => o.OrderOut == null && !o.Canceled).ToList();
    }

    public List<Order> GetCanceledOrders()
    {
      return GetOrders().Where(o => o.Canceled).ToList();
    }

    public OrdersService(
      OrdersRepository repo,
      ItemsService bs)
    {
      _repo = repo;
      _bs = bs;
    }

    internal Order GetOrderById(string id)
    {
      var order = _repo.GetOrderById(id);
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

      _repo.Create(orderData);
      orderData.Food.ForEach(item =>
      {
        _repo.CreateOrderItem(orderData.Id, item.Id);
      });

      return orderData;
    }

    internal Order CancelOrder(string id, string userId)
    {
      var order = GetOrderById(id);

      if (userId != order.UserId)
      {
        throw new Exception("That's not your order.... You don't even go here");
      }

      if (order.OrderOut != null)
      {
        throw new Exception("Order cannot be canceled after it was fullfilled");
      }
      order.Canceled = true;
      _repo.SaveOrder(order);
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
      _repo.SaveOrder(order);
      return order;
    }
  }
}