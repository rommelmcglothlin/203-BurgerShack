using System;
using System.Collections.Generic;
using System.Linq;
using BurgerShack.Data;
using BurgerShack.Models;

namespace BurgerShack.Services
{
  public class BurgersService
  {
    private readonly FakeDb _repo;

    public Burger AddBurger(Burger burgerData)
    {
      var exists = _repo.Burgers.Find(b => b.Name == burgerData.Name);
      if (exists != null)
      {
        throw new Exception("This burger already exists.");
      }
      burgerData.Id = Guid.NewGuid().ToString();
      _repo.Burgers.Add(burgerData);
      return burgerData;
    }

    public Burger EditBurger(Burger burgerData)
    {
      var burger = _repo.Burgers.Find(b => b.Id == burgerData.Id);
      if (burger == null) { throw new Exception("I DONT LIKE BAD ID's"); }
      burger.Name = burgerData.Name;
      burger.Description = burgerData.Description;
      burger.Price = burgerData.Price;
      return burger;
    }

    public Burger DeleteBurger(string id){
      var burger = _repo.Burgers.Find(b => b.Id == id);
      if (burger == null) { throw new Exception("I DONT LIKE BAD ID's"); }
      _repo.Burgers.Remove(burger);
      return burger;
    }

    public List<Burger> GetBurgers()
    {
      return _repo.Burgers;
    }

    public BurgersService(FakeDb repo)
    {
      _repo = repo;
    }
  }
}