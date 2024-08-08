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

INSERT INTO producto(prod_nombre, prod_descripcion, prod_precio)
VALUES
("Banana", "Bananashi", 0),
("Manzana", "Es una manza viejo", 30),
("Producto", "no se es un producto", 60);