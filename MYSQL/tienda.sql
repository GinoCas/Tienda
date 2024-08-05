DROP DATABASE IF EXISTS TiendaDB;
CREATE DATABASE TiendaDB;

USE TiendaDB;

CREATE TABLE Producto(
	prod_id INT UNSIGNED NOT NULL,
	prod_nombre VARCHAR(50) NOT NULL,
	prod_descripcion TEXT,
	prod_precio DECIMAL(12,4),
	PRIMARY KEY(prod_id)
);
