DROP DATABASE IF EXISTS TiendaDB;
CREATE DATABASE TiendaDB;

USE TiendaDB;

CREATE TABLE Products(
	prod_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
	prod_code VARCHAR(100) NOT NULL UNIQUE, # Stand by
	prod_name VARCHAR(100) NOT NULL,
	prod_description TEXT,
	prod_price DECIMAL(12,4) UNSIGNED NOT NULL DEFAULT 0,
	prod_stock INT UNSIGNED NOT NULL DEFAULT 0,
	PRIMARY KEY(prod_id)
);

CREATE TABLE Users(
	user_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
	user_name VARCHAR(50) NOT NULL,
	user_surname VARCHAR(50) NOT NULL,
	user_email VARCHAR(50) NOT NULL UNIQUE,
	user_password VARCHAR(100) NOT NULL,
	user_createdAt DATE NOT NULL DEFAULT(NOW()),
	PRIMARY KEY(user_id)
);

CREATE TABLE Orders(
	orde_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
	orde_userId INT UNSIGNED NOT NULL,
	orde_createdAt TIMESTAMP NOT NULL DEFAULT(NOW()),
	orde_pending BOOL NOT NULL DEFAULT(TRUE),
	orde_total DECIMAL(12,4) UNSIGNED NOT NULL DEFAULT 0,
	PRIMARY KEY(orde_id)
);

CREATE TABLE ProductOrder(
	pror_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
	pror_orderId INT UNSIGNED NOT NULL,
	pror_productId INT UNSIGNED NOT NULL,
	pror_quantity INT UNSIGNED NOT NULL DEFAULT 1,
	PRIMARY KEY(pror_id)
);

INSERT INTO Products(prod_name, prod_code, prod_description, prod_price, prod_stock)
VALUES
("WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW", "211", "Es una banana muy rica", 20, 5),
("Banana", "21231", "Es una banana muy rica", 99999999.9999, 10),
("Banana 2.0", "31", "La otra banana era muy cara asi que inventamos la banana 2.0", 10.23567231, 10),
("Manzana", "78271", "Es una manzana muy rica", 15, 10),
("Naranja", "332103", "Es una naranja muy rica", 12.365, 10);

INSERT INTO Users(user_name, user_surname, user_email, user_password) 
VALUES
("Gino", "Casentini", "gino.casentini@gmail.com", "ginocas12");