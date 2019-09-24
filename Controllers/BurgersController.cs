using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurgerShack.Models;
using BurgerShack.Services;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BurgersController : ControllerBase
  {
    private readonly BurgersService _bs;

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Burger>> Get()
    {
      return _bs.GetBurgers();
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Burger> Get(string id)
    {
      try
      {
        Burger burger = _bs.GetBurgerById(id);
        return Ok(burger);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // POST api/values
    [HttpPost]
    public ActionResult<Burger> Post([FromBody] Burger burgerData)
    {
      try
      {
        Burger myBurger = _bs.AddBurger(burgerData);
        return Ok(myBurger);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message); //code snippet
      }
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<Burger> Put(string id, [FromBody] Burger burgerData)
    {
      try
      {
        burgerData.Id = id;
        var burger = _bs.EditBurger(burgerData);
        return Ok(burger);
      }
      catch (Exception e) { return BadRequest(e.Message); }
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<Burger> Delete(string id)
    {
      try
      {
        var burger = _bs.DeleteBurger(id);
        return Ok(burger);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    public BurgersController(BurgersService bs)
    {
      _bs = bs;
    }
  }
}