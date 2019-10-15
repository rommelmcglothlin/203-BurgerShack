using System.Collections.Generic;

namespace BurgerShack.Models
{
  public class Course
  {
    public string _id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
  }

  public class BCWResponse<T>
  {
    public string Name { get; set; }
    public string Action { get; set; }
    public List<T> Data { get; set; }
  }

}