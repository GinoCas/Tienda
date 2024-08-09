DROP DATABASE IF EXISTS TiendaDB;
CREATE DATABASE TiendaDB;

USE TiendaDB;

CREATE TABLE Producto(
	prod_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
	prod_nombre VARCHAR(50) NOT NULL,
	prod_descripcion TEXT,
	prod_precio DECIMAL(12,4),
	PRIMARY KEY(prod_id)
);

CREATE TABLE Usuario(
	user_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
	user_nombre VARCHAR(50) NOT NULL,
	user_password VARCHAR(50) NOT NULL,
	PRIMARY KEY(user_id)
);

INSERT INTO producto(prod_nombre, prod_descripcion, prod_precio)
VALUES
("Banana", "Bananashi", 0),
("Manzana", "Es una manza viejo", 30),
("Producto", "no se es un producto", 60);

INSERT INTO Usuario(user_nombre, user_password) 
VALUES
("Gino", "cas");
#UPDATE PRODUCTO SET prod_nombre = 'Banana 2.0', prod_descripcion = 'Es una bananashi 2.0', prod_precio = 1 WHERE prod_id = 1