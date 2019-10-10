using System;

namespace BurgerShack.Exceptions
{
  public class MyExceptionType : Exception
  {
    public string NO { get; set; }
    public MyExceptionType(string message) : base(message)
    {
      NO = message.ToUpper();
    }
  }
}