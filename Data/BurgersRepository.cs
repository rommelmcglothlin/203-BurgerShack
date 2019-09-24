using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Data
{
    public class BurgersRepository
    {
        private readonly IDbConnection _db;

        public Burger Create(Burger burgerData)
        {
            var sql = @"INSERT INTO burgers
            (id, name, description, price)
            VALUES
            (@Id, @Name, @Description, @Price);";
            _db.Execute(sql, burgerData);
            return burgerData;
        }

        public IEnumerable<Burger> GetAll()
        {
            return _db.Query<Burger>("SELECT * FROM burgers");
        }

        public BurgersRepository(IDbConnection db)
        {
            _db = db;
        }

    }
}