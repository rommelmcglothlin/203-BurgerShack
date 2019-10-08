using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Data
{
    public class OrdersRepository
    {
        private readonly IDbConnection _db;

        public Order Create(Order orderData)
        {
            var sql = @"INSERT INTO orders
            (id, name, orderin)
            VALUES
            (@Id, @Name, @OrderIn);";
            var x = _db.Execute(sql, orderData);

            return orderData;
        }

        public IEnumerable<Order> GetAll()
        {
            return _db.Query<Order>("SELECT * FROM orders");
        }

        public Order GetOrderById(string id)
        {
            return _db.QueryFirstOrDefault<Order>(
                "SELECT * FROM orders WHERE id = @id",
                new { id } // Dapper requires all @prop to be an actual property on an object
            );
        }

        internal bool SaveOrder(Order Order)
        {
            var nRows = _db.Execute(@"
                UPDATE orders SET
                name = @Name,
                orderout = @OrderOut,
                canceled = @Canceled,
                ordercanceledat = @OrderCanceledAt
                WHERE id = @Id
                ", Order);
            return nRows == 1;
        }

        internal bool DeleteOrder(string id)
        {
            var success = _db.Execute("DELETE FROM orders WHERE id = @id", new { id });
            if (success == 1)
            {
                return true;
            }
            return false;
        }

        internal bool CreateOrderItem(string orderId, string itemId, string mods = "")
        {
            //TODO Refactor this
            var id = Guid.NewGuid().ToString();
            var sql = "INSERT INTO orderitems (id, itemid, orderid, modifications)VALUES (@id, @itemId, @orderId,@mods)";
            var success = _db.Execute(sql, new { orderId, itemId, mods, id });
            return success == 1;

        }

        public Order GetFullOrder(string orderId)
        {
            var burgersSQL = @"SELECT
                b.name,
                b.price,
                oi.modifications,
                FROM orderitems
                JOIN burgers b ON b.id = oi.itemid
                WHERE o.orderid = @orderId;";
            var burgers = _db.Query<Item>(burgersSQL, new { orderId }).AsList();

            var orderSql = "SELECT * FROM orders where id = @orderId";
            var order = _db.QueryFirst<Order>(orderSql, new { orderId });

            order.Food = burgers;
            return order;
        }

        public OrdersRepository(IDbConnection db)
        {
            _db = db;
        }

    }
}