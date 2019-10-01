using System;
using System.Collections.Generic;
using System.Linq;
using BurgerShack.Data;
using BurgerShack.Models;

namespace BurgerShack.Services
{
  public class SidesService
  {
    private readonly SidesRepository _repo;

    public Side AddSide(Side sideData)
    {
      var exists = _repo.GetSideByName(sideData.Name);
      if (exists != null)
      {
        throw new Exception("This side already exists");
      }
      sideData.Id = Guid.NewGuid().ToString();
      return sideData;
    }

    public Side EditSide(Side sideData)
    {
      var side = GetSideById(sideData.Id);
      side.Name = sideData.Name;
      side.Description = sideData.Description;
      side.Price = sideData.Price;

      bool success = _repo.SaveSide(side);

      if (!success)
      {
        throw new Exception("Side couldn't be saved. Please try again");
      }
      return side;

    }

    public Side GetSideById(string id)
    {
      var side = _repo.GetSideById(id);
      if (side == null)
      {
        throw new Exception("Not a valid ID");
      }
      return side;
    }

    public Side DeleteSide(string id)
    {
      var side = GetSideById(id);
      var deleted = _repo.DeleteSide(id);
      if (!deleted)
      {
        throw new Exception($"Unable to remove burger at Id {id} ");
      }
      return side;
    }

    public List<Side> GetSides()
    {
      return _repo.GetAll().ToList();
    }

    public SidesService(SidesRepository repo)
    {
      _repo = repo;
    }
  }
}