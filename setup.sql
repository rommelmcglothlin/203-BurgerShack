-- CREATE TABLE users (
--   id VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL UNIQUE,
--   username VARCHAR(255) NOT NULL,

--   PRIMARY KEY (id)
-- );

-- ALTER TABLE users
--   ADD hash VARCHAR(255) NOT NULL;

-- CREATE TABLE IF NOT EXISTS items (
--   id VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255),
--   type VARCHAR(255) NOT NULL,
--   price decimal(3,2) DEFAULT .99,

--   PRIMARY KEY(id)
-- );

-- CREATE PROCEDURE get_users()
-- BEGIN
--   SELECT * FROM users;
-- END
-- CALL get_users();

-- DROP PROCEDURE create_user;
-- CREATE PROCEDURE create_user(id varchar(255), email varchar(255), username varchar(255))
-- BEGIN
--   INSERT INTO users (id, email, username, hash) VALUES(id, email, username, "password");
-- END;

-- CALL create_user("1", "t@test.com", "TESTERMCTEST");


-- CREATE TABLE orders
-- (
--   id VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   canceled TINYINT DEFAULT 0,
--   orderin DATETIME NOT NULL,
--   orderout DATETIME, 
--   ordercanceledat DATETIME,
--   userid VARCHAR(255) NOT NULL,

--   FOREIGN KEY(userid)
--     REFERENCES users(id),

--   PRIMARY KEY(id)
  
-- );

-- CREATE TABLE orderitems
-- (
--   id VARCHAR(255) NOT NULL,
--   itemid VARCHAR(255) NOT NULL,
--   orderid VARCHAR(255) NOT NULL,
--   modifications VARCHAR(255),

--   FOREIGN KEY(itemid)
--     REFERENCES items(id),
--   FOREIGN KEY(orderid)
--     REFERENCES orders(id),
--   PRIMARY KEY(id)
-- );


-- CREATE PROCEDURE CreateItem(id VARCHAR(255), name VARCHAR(255), type VARCHAR(255))
-- BEGIN
--   INSERT INTO items (id, name, type) VALUES (id, name, type);
-- END;

-- CALL CreateItem("item-2", "Small Kahuna", "burger");
-- CALL CreateItem("item-3", "Bacon Bacon", "burger");
-- CALL CreateItem("item-4", "Coke", "drink");
-- CALL CreateItem("item-5", "Cheesy Bacon Fries", "side");

-- ALTER TABLE items
--   ADD COLUMN img VARCHAR(255);



