using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurgerShack.Models;
using BurgerShack.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class OrdersController : ControllerBase
  {
    private readonly OrdersService _os;

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Order>> Get()
    {
      return _os.GetOrders();
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Order> Get(string id)
    {
      try
      {
        Order order = _os.GetOrderById(id);
        return Ok(order);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // POST api/values
    [HttpPost]
    public ActionResult<Order> Post([FromBody] Order orderData)
    {
      try
      {
        orderData.UserId = HttpContext.User.FindFirst("Id").Value;
        Order myOrder = _os.AddOrder(orderData);
        return Created("api/orders/" + myOrder.Id, myOrder);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message); //code snippet
      }
    }

    // PUT api/values/5
    [HttpPut("{id}/fulfill")]
    public ActionResult<Order> Put(string id)
    {
      try
      {
        var order = _os.FulfillOrder(id);
        return Ok(order);
      }
      catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpPut("{id}/cancel")]
    public ActionResult<Order> CancelOrder(string id)
    {
      try
      {
        var userId = HttpContext.User.FindFirst("Id").Value;
        Order order = _os.CancelOrder(id, userId);
        return Ok(order);
      }
      catch (Exception e) { return BadRequest(e.Message); }
    }

    public OrdersController(OrdersService os)
    {
      _os = os;
    }
  }
}