-- Crear la base de datos
CREATE DATABASE store;
GO

-- Usar la base de datos
USE store;
GO

-- Crear la tabla "brands"
CREATE TABLE brands (
    id INT PRIMARY KEY,
    descripcion VARCHAR(255) NOT NULL,
    tipo VARCHAR(255) NOT NULL
);
GO

-- Insertar datos en la tabla "brands"
INSERT INTO brands (id, descripcion, tipo) VALUES
(1, 'Bic Color', 'original'),
(3, 'Totto', 'generico'),
(4, 'Magicolor', 'original'),
(5, 'Bic Color', 'generico'),
(6, 'Magicolor', 'generico'),
(7, 'Totto', 'original');
GO

-- Crear la tabla "categories"
CREATE TABLE categories (
    id INT PRIMARY KEY,
    descripcion VARCHAR(45) NOT NULL
);
GO

-- Insertar datos en la tabla "categories"
INSERT INTO categories (id, descripcion) VALUES
(4, 'Marcador permanente'),
(3, 'Lapiceros'),
(1, 'libros'),
(2, 'Lapices'),
(5, 'Crayones'),
(6, 'Bolsones');
GO

-- Crear la tabla "inventory"
CREATE TABLE inventory (
    id_inventory INT PRIMARY KEY,
    date_in DATE NOT NULL,
    date_out DATE NOT NULL,
    id_product INT NOT NULL,
    stock_in INT NOT NULL,
    entries INT NOT NULL,
    outlets INT NOT NULL
);
GO

-- Insertar datos en la tabla "inventory"
INSERT INTO inventory (id_inventory, date_in, date_out, id_product, stock_in, entries, outlets) VALUES
(2, '2022-09-30', '2022-10-14', 567, 567, 879, 789),
(6, '2022-09-29', '2022-10-20', 34, 65, 8, 67),
(5, '2022-09-30', '2022-10-21', 23, 100, 500, 400),
(7, '2022-09-29', '2022-10-29', 234, 234, 24, 234),
(8, '2022-09-27', '2022-10-29', 7, 20, 10, 5),
(9, '2022-09-26', '2022-10-05', 10, 5, 4, 2),
(10, '2022-02-02', '2022-06-01', 8, 50, 20, 38),
(11, '2022-07-07', '2022-09-14', 9, 47, 30, 32);
GO

-- Crear la tabla "products"
CREATE TABLE products (
    id_producto INT PRIMARY KEY,
    descripcion VARCHAR(250) NOT NULL,
    id_marca INT NOT NULL,
    id_categoria INT NOT NULL,
    imagen VARCHAR(800) DEFAULT NULL
);
GO

ALTER TABLE Products
ADD precio_unitario DECIMAL(10, 2);


-- Crear la tabla "usser"
CREATE TABLE usser (
    id INT PRIMARY KEY,
    name VARCHAR(250) NOT NULL,
    last_name VARCHAR(250) NOT NULL,
    ussers VARCHAR(250) NOT NULL,
    pswd VARCHAR(250) NOT NULL,
    type_usser VARCHAR(30) NOT NULL
);
GO

-- Insertar

-- Agregar relación entre las tablas "inventory" y "products"
ALTER TABLE inventory
ADD CONSTRAINT FK_Inventory_Products
FOREIGN KEY (id_product) REFERENCES products(id_producto);


select * from dbo.inventory;
select * from dbo.products;
select * from dbo.brands;
select * from dbo.Sales;
select * from dbo.SalesItems;



-- Insertar datos en la tabla "products"
INSERT INTO products (id_producto, descripcion, id_marca, id_categoria, imagen, precio_unitario) VALUES
(567, 'Lapicero', 1, 4, 'imagen567.jpg', 2.25),
(23, 'Regla', 5, 2, 'imagen23.jpg', 2.00),
(34, 'Lapiz', 4, 3, 'imagen34.jpg', 1.50),
(234, 'Borrador', 3, 5, 'imagen234.jpg', 2.00),
(7, 'Hojas', 1, 1, 'imagen7.jpg', 0.25),
(10, 'Calculadora', 6, 6, 'imagen10.jpg', 15.00),
(8, 'Cuaderno Cuadricula', 4, 4, 'imagen8.jpg', 4.25),
(9, 'Cuaderno Lineas', 3, 3, 'imagen9.jpg', 5.00);

update products set precio_unitario = 5.00 where id_producto = 9


CREATE TABLE Customers (
  id_cliente INT PRIMARY KEY,
  nombre VARCHAR(250),
  direccion VARCHAR(250),
  telefono VARCHAR(20)
);

CREATE TABLE Sales (
  id_venta INT PRIMARY KEY,
  fecha_venta DATE,
  id_cliente INT,
  total DECIMAL(10, 2),
  FOREIGN KEY (id_cliente) REFERENCES Customers(id_cliente)
);


CREATE TABLE SalesItems (
  id_venta INT,
  id_producto INT,
  cantidad INT,
  subtotal DECIMAL(10, 2),
  FOREIGN KEY (id_venta) REFERENCES Sales(id_venta),
  FOREIGN KEY (id_producto) REFERENCES Products(id_producto)
);

ALTER TABLE SalesItems
ADD SalesItemId INT IDENTITY(1,1) PRIMARY KEY;

