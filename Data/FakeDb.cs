using System.Collections.Generic;
using BurgerShack.Models;

namespace BurgerShack.Data
{
  public class FakeDb
  {
    public List<Burger> Burgers { get; set; } = new List<Burger>();
    public List<Drink> Drinks { get; set; } = new List<Drink>();
    public List<Side> Sides { get; set; } = new List<Side>();

  }
}