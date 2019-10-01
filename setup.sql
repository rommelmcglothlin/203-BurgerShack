-- CREATE TABLE IF NOT EXISTS burgers (
--   id VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255),
--   price decimal(3,2) DEFAULT .99,

--   PRIMARY KEY(id)
-- );

-- INSERT INTO burgers (id, name, description, price)
-- VALUES ("burger-1", "Big Kahuna", "Pineapple Yum", 7.99);


-- ALTER TABLE burgers 
--  MODIFY price decimal(3,2);

-- UPDATE burgers 
-- SET price = 7.99
-- WHERE id = "burger-1";


-- DELETE FROM burgers WHERE id = "burger-1";


-- SELECT * FROM burgers;

-- CREATE TABLE orders
-- (
--   id VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   canceled TINYINT DEFAULT 0,
--   orderin DATETIME NOT NULL,
--   orderout DATETIME, 
--   ordercanceledat DATETIME,

--   PRIMARY KEY(id)
  
-- );

-- CREATE TABLE orderitems
-- (
--   id VARCHAR(255) NOT NULL,
--   itemid VARCHAR(255) NOT NULL,
--   orderid VARCHAR(255) NOT NULL,
--   modifications VARCHAR(255),

--   FOREIGN KEY(itemid)
--     REFERENCES burgers(id),
--   FOREIGN KEY(orderid)
--     REFERENCES orders(id),
--   PRIMARY KEY(id)
-- );

-- DROP TABLE orderitems;

-- INSERT INTO orders (id, name, orderin)
-- VALUES ("yru397", "Jake", "2019-09-30 14:00:00");

-- INSERT INTO orderitems (id, itemid, orderid, modifications)
-- VALUES ("elt987", "burger-1", "yru397", "no bun - low carb");

SELECT
  o.id "order id",
  o.name "customer name",
  b.name "burger name",
  b.price,
  oi.modifications,
  o.orderin,
  o.orderout,
  o.canceled
 FROM orders o
  JOIN orderitems oi ON o.id = oi.orderid
  JOIN burgers b ON b.id = oi.itemid
  WHERE o.id = "yru397";
