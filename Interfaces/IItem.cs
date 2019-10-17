namespace BurgerShack.Interfaces
{
  public interface IItem
  {
    string Id {get; set;}
    string Name { get; set; }
    string Description { get; set; }
    decimal Price {get; set;}
    string Img {get;set;}
  }


}

