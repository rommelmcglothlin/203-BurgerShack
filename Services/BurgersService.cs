using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BurgerShack.Data;
using BurgerShack.Interfaces;
using BurgerShack.Models;
using Microsoft.AspNetCore.Http;

namespace BurgerShack.Services
{
  public class ItemsService
  {
    private ItemsRepository _repo;

    /// <summary>
    /// Creates a burger if the name is unique otherwise throws an exception
    /// </summary>
    /// <param name="burgerData"></param>
    /// <returns></returns>
    public Burger AddBurger(Burger burgerData)
    {
      var exists = _repo.GetBurgerByName(burgerData.Name);
      if (exists != null)
      {
        throw new Exception("This burger already exists.");
      }
      burgerData.Id = Guid.NewGuid().ToString();
      _repo.Create(burgerData);
      return burgerData;
    }

    public Burger EditBurger(Burger burgerData)
    {
      var burger = GetBurgerById(burgerData.Id);
      burger.Name = burgerData.Name;
      burger.Description = burgerData.Description;
      burger.Price = burgerData.Price;

      bool success = _repo.SaveBurger(burger);

      if (!success)
      {
        throw new Exception("Nope I couldn't update the burger.... Please Try Again Later, or now is probably fine");
      }

      return burger;
    }

    /// <summary>
    /// Returns a burger by its id or throws an exception
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Burger GetBurgerById(string id)
    {
      var burger = _repo.GetBurgerById(id);
      if (burger == null) { throw new Exception("I DONT LIKE BAD ID's"); }
      return burger;
    }

    public Burger DeleteBurger(string id)
    {
      var burger = GetBurgerById(id);
      var deleted = _repo.DeleteBurger(id);

      if (!deleted)
      {
        throw new Exception($"Unable to remove burger at Id {id}");
      }

      return burger;
    }

    public List<Burger> GetBurgers()
    {
      return _repo.GetAll().ToList();
    }

    internal async Task<IItem> AddImage(string id, IFormFile file)
    {
      var item = GetBurgerById(id);
      var photoName = item.Name + file.FileName.Substring(file.FileName.LastIndexOf("."));
      var img = await WriteToFile("wwwroot/images", photoName, file);
      item.Img = img;
      _repo.SaveBurger(item);
      return item;
    }

    public async Task<string> WriteToFile(string path, string FileName, IFormFile file)
    {

      if (!Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
      }

      var filePath = Path.Combine(path, FileName);
      using(var fileStream = new FileStream(filePath, FileMode.Create))
      {
        await file.CopyToAsync(fileStream);
        return "images/"+FileName;
      }
    }

    public ItemsService(ItemsRepository repo)
    {
      _repo = repo;
    }
  }
}