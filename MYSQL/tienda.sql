DROP DATABASE IF EXISTS TiendaDB;
CREATE DATABASE TiendaDB;

USE TiendaDB;

CREATE TABLE Products(
	prod_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
	prod_name VARCHAR(50) NOT NULL,
	prod_description TEXT,
	prod_value DECIMAL(12,4),
	PRIMARY KEY(prod_id)
);

CREATE TABLE Users(
	user_id INT UNSIGNED NOT NULL AUTO_INCREMENT UNIQUE,
	user_name VARCHAR(50) NOT NULL,
	user_password VARCHAR(100) NOT NULL,
	user_entrydate DATE NOT NULL DEFAULT(NOW()),
	PRIMARY KEY(user_id)
);

INSERT INTO Products(prod_name, prod_description, prod_value)
VALUES
("Banana", "Bananashi", 0),
("Manzana", "Es una manza viejo", 30),
("Producto", "no se es un producto", 60);

INSERT INTO Users(user_name, user_password) 
VALUES
("Gino", "cas");
#UPDATE PRODUCTO SET prod_nombre = 'Banana 2.0', prod_descripcion = 'Es una bananashi 2.0', prod_precio = 1 WHERE prod_id = 1