using System.ComponentModel.DataAnnotations;
using BurgerShack.Interfaces;

namespace BurgerShack.Models
{
  public class Item : IItem
  {
    [Required]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    [Required]
    public string Type { get; set; }
  }

}