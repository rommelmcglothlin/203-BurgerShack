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
    public string Img { get; set; }

    public string Modifications { get; set; }

    [Required]
    public string Type { get; set; }
  }

  public class THISTHATRELATIONSHIP
  {
    public string Id { get; set; }
    public string THISID { get; set; }
    public string THATID { get; set; }
    public string Action { get; set; }
  }

}