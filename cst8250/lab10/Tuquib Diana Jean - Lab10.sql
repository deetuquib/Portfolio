-- Create database
CREATE DATABASE triggers_db;
USE triggers_db;

-- Create 'product' table
CREATE TABLE product (
  product_id INT auto_increment PRIMARY KEY,
  name VARCHAR(100),
  quantity INT,
  price DECIMAL(5,2)
);

-- Insert 4 or 5 rows of data into this table
INSERT INTO product (
     name,
     quantity,
     price
 ) VALUES
    ('Godiva', 5, 15.00),
    ('Lindt', 10, 30.00),
    ('Milka', 7, 21.00),
    ('Merci', 15, 45.00);

-- Create 'product_log' table
CREATE TABLE product_log (
  log_id int auto_increment PRIMARY KEY,
  product_id INT,
  name VARCHAR(100),
  quantity INT,
  price DECIMAL(5,2)
);

-- Create update trigger that will log all changes to exiting data
DROP TRIGGER update_trg;

DELIMITER $$
CREATE TRIGGER update_trg
AFTER UPDATE ON product
    FOR EACH ROW
    BEGIN
        INSERT INTO product_log (product_id, name, quantity, price)
        VALUES (OLD.product_id, OLD.name, OLD.quantity, OLD.price);
    END; $$

-- test update trigger
UPDATE product SET quantity = 20, price = 60.00 WHERE name = 'Milka';

-- Create delete trigger that will log all changes to exiting data
DELIMITER $$
CREATE TRIGGER delete_trg
AFTER DELETE ON product
    FOR EACH ROW
    BEGIN
        INSERT INTO product_log (product_id, name, quantity, price)
        VALUES (OLD.product_id, OLD.name, OLD.quantity, OLD.price);
    END; $$

-- test delete trigger
DELETE FROM product WHERE quantity > 4;

