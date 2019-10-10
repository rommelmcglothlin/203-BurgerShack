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

