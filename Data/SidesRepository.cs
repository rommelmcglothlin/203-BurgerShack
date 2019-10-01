using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Data
{
  public class SidesRepository
  {
    private readonly IDbConnection _sd;

    public Side Create(Side sideData)
    {
      var sql = @"INSERT INTO sides
                (id, name, description, price)
                VALUES
                (@Id, @Name, @Description, @Price);";
      var x = _sd.Execute(sql, sideData);

      return sideData;

    }

    public IEnumerable<Side> GetAll()
    {
      return _sd.Query<Side>("SELECT * FROM sides");
    }

    public Side GetSideByName(string name)
    {
      return _sd.QueryFirstOrDefault<Side>
      (
          "SELECT * FROM sides WHERE name = @Name",
          new { name }
      );
    }

    public Side GetSideById(string id)
    {
      return _sd.QueryFirstOrDefault<Side>(
          "SELECT * FROM sides WHERE id = @id",
          new { id }
      );
    }

    internal bool SaveSide(Side side)
    {
      var nRows = _sd.Execute(@"
                UPDATE sides SET
                name = @Name,
                description = @Description, 
                price = @price
                WHERE id = @Id
                ", side);
      return true;

    }

    internal bool DeleteSide(string id)
    {
      var success = _sd.Execute("DELETE FROM sides WHERE id = @id", new { id });
      if (success == 1)
      {
        return true;
      }
      return false;

    }

    public SidesRepository(IDbConnection sd)

    {
      _sd = sd;
    }


  }
}