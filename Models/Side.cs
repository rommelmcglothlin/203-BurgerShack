using BurgerShack.Interfaces;

namespace BurgerShack.Models
{
  public class Side : IItem
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Img { get; set; }

  }

}