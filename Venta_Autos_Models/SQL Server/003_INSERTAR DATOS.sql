USE Proyecto_PAW_Venta_Autos;

-- Insertar un usuario administrador
INSERT INTO USUARIO(Nombres, Apellidos, Correo, Contrasena, EsAdministrador) 
VALUES ('Administrador', 'Principal', 'admin@example.com', 'admin123', 1);

GO

-- Insertar categorías de productos
INSERT INTO CATEGORIA(Descripcion) VALUES
('Autos'),
('Accesorios'),
('Repuestos');

GO

-- Insertar marcas de autos
INSERT INTO MARCA(Descripcion) VALUES
('Toyota'),
('Honda'),
('Ford'),
('Chevrolet'),
('BMW'),
('Mercedes-Benz'),
('Audi');

GO

-- Insertar productos (autos)
INSERT INTO PRODUCTO(Nombre, Descripcion, IdMarca, IdCategoria, Precio, Stock, RutaImagen) 
VALUES('Toyota Corolla', 'Auto sedán compacto', 1, 1, 25000, 10, '~/Imagenes/Productos/1.jpg');

INSERT INTO PRODUCTO(Nombre, Descripcion, IdMarca, IdCategoria, Precio, Stock, RutaImagen) 
VALUES('Honda Civic', 'Auto sedán mediano', 2, 1, 28000, 8, '~/Imagenes/Productos/2.jpg');

INSERT INTO PRODUCTO(Nombre, Descripcion, IdMarca, IdCategoria, Precio, Stock, RutaImagen) 
VALUES('Ford Mustang', 'Auto deportivo', 3, 1, 40000, 5, '~/Imagenes/Productos/3.jpg');

INSERT INTO PRODUCTO(Nombre, Descripcion, IdMarca, IdCategoria, Precio, Stock, RutaImagen) 
VALUES('Chevrolet Tahoe', 'SUV grande', 4, 1, 55000, 3, '~/Imagenes/Productos/4.jpg');

INSERT INTO PRODUCTO(Nombre, Descripcion, IdMarca, IdCategoria, Precio, Stock, RutaImagen) 
VALUES('BMW Serie 3', 'Auto de lujo', 5, 1, 60000, 7, '~/Imagenes/Productos/5.jpg');

GO