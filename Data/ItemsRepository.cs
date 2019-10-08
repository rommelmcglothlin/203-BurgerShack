using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Data
{
    public class ItemsRepository
    {
        private readonly IDbConnection _db;

        public Burger Create(Burger burgerData)
        {
            var sql = @"INSERT INTO items
            (id, name, description, price)
            VALUES
            (@Id, @Name, @Description, @Price);";
            var x = _db.Execute(sql, burgerData);

            return burgerData;
        }

        public IEnumerable<Burger> GetAll()
        {
            return _db.Query<Burger>("SELECT * FROM items");
        }

        public Burger GetBurgerByName(string name)
        {
            return _db.QueryFirstOrDefault<Burger>(
                "SELECT * FROM items WHERE name = @name",
                new { name } // Dapper requires all @prop to be an actual property on an object
            );
        }

        public Burger GetBurgerById(string id)
        {
            return _db.QueryFirstOrDefault<Burger>(
                "SELECT * FROM items WHERE id = @id",
                new { id } // Dapper requires all @prop to be an actual property on an object
            );
        }

        internal bool SaveBurger(Burger burger)
        {
            var nRows = _db.Execute(@"
                UPDATE items SET
                name = @Name,
                description = @Description,
                price = @Price
                WHERE id = @Id
                ", burger);
            return nRows == 1;
        }

        internal bool DeleteBurger(string id)
        {
            var success = _db.Execute("DELETE FROM items WHERE id = @id", new { id });
            if (success == 1)
            {
                return true;
            }
            return false;
        }

        public ItemsRepository(IDbConnection db)
        {
            _db = db;
        }

    }
}