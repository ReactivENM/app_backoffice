DROP DATABASE IF EXISTS quickcarry;
CREATE DATABASE IF NOT EXISTS quickcarry CHARACTER SET utf8 COLLATE utf8_general_ci;
USE quickcarry;

-- Tabla de Usuarios
CREATE TABLE Usuario (
    id INT AUTO_INCREMENT PRIMARY KEY,
    correo VARCHAR(50) NOT NULL,
    contrasena VARCHAR(128) NOT NULL,
    p_nombre VARCHAR(50) NOT NULL,
    s_nombre VARCHAR(50),
    p_apellido VARCHAR(50) NOT NULL,
    s_apellido VARCHAR(50),
    nro_documento INT UNSIGNED NOT NULL UNIQUE,
    nacionalidad VARCHAR(50) NOT NULL,
    deshabilitado BIT NOT NULL DEFAULT 0,
    rol ENUM('Administrador', 'Almacenero', 'Camionero')
);

-- Tabla de Almacenes
CREATE TABLE Almacen (
    id INT AUTO_INCREMENT PRIMARY KEY,
    descripcion VARCHAR(100),
    calle VARCHAR(100) NOT NULL,
    nro_puerta VARCHAR(20) NOT NULL,
    cod_postal VARCHAR(10) NOT NULL,
    capacidad INT NOT NULL,
    departamento VARCHAR(50) NOT NULL
);

-- Tabla de Clientes
CREATE TABLE Cliente (
    id int AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    calle VARCHAR(100) NOT NULL,
    telefono VARCHAR(15) NOT NULL
);

-- Tabla de Relación Usuario-Administra-Almacen
CREATE TABLE UsuarioAlmacen (
    id_usuario INT,
    id_almacen INT,
    UNIQUE (id_usuario, id_almacen),
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id),
    FOREIGN KEY (id_almacen) REFERENCES Almacen(id)
);

-- Tabla de Paquetes
CREATE TABLE Paquete (
    id_interno INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    id_externo VARCHAR(50),
    id_cliente INT,
    peso DECIMAL(10, 2) NOT NULL,
    dir_envio VARCHAR(100) NOT NULL,
    estado ENUM('en_espera', 'en_viaje', 'entregado'),
    FOREIGN KEY(id_cliente) REFERENCES Cliente(id)
);

-- Tabla de Lotes
CREATE TABLE Lote (
    id INT AUTO_INCREMENT PRIMARY KEY,
    id_almacen INT NOT NULL,
    estado ENUM('en_espera', 'en_viaje', 'entregado'),
    FOREIGN KEY (id_almacen) REFERENCES Almacen(id)
);

-- Tabla de Relación Paquete-Lote
CREATE TABLE PaqueteLote (
    id_interno_paquete INT UNSIGNED NOT NULL,
    id_lote INT,
    id_usuario INT,
    fecha_hora DATETIME DEFAULT CURRENT_TIMESTAMP,
    UNIQUE (id_interno_paquete, id_lote, id_usuario),
    FOREIGN KEY (id_interno_paquete) REFERENCES Paquete(id_interno) ON DELETE CASCADE,
    FOREIGN KEY (id_lote) REFERENCES Lote(id),
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id) ON DELETE CASCADE
);

-- Tabla de Camiones
CREATE TABLE Camion (
    id INT AUTO_INCREMENT PRIMARY KEY,
    marca VARCHAR(50) NOT NULL,
    modelo VARCHAR(50) NOT NULL,
    matricula VARCHAR(20) UNIQUE NOT NULL, 
    capacidad DECIMAL(3, 1) NOT NULL
);

-- Tabla de Usuarios que Conducen Camiones
CREATE TABLE UsuarioCamion (
    id_usuario INT,
    id_camion INT,
    fecha DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id) ON DELETE CASCADE,
    FOREIGN KEY (id_camion) REFERENCES Camion(id)
);

-- Tabla de CamionEntradaSalida
CREATE TABLE CamionEntradaSalida (
    id INT AUTO_INCREMENT PRIMARY KEY,
    id_camion INT,
    fecha_hora DATETIME DEFAULT CURRENT_TIMESTAMP,
    tipo_operacion ENUM('entrada', 'salida'),
    observaciones VARCHAR(200),
    FOREIGN KEY (id_camion) REFERENCES Camion(id)
);

-- Tabla de Relación Camión-Lleva-Lote
CREATE TABLE CamionLote (
	id INT AUTO_INCREMENT PRIMARY KEY,
    id_camion INT,
    id_lote INT,
    UNIQUE (id_camion, id_lote),
    FOREIGN KEY (id_camion) REFERENCES Camion(id),
    FOREIGN KEY (id_lote) REFERENCES Lote(id)
);

-- INSERTS
INSERT INTO Usuario(correo, contrasena, p_nombre, s_nombre, p_apellido, s_apellido, nro_documento, nacionalidad, rol) VALUES
	('josepedro@gmail.com', '9c87400128d408cdcda0e4b3ff0e66fa', 'José', 'Pedro', 'Rodriguez', 'Gonzales', '44335566', 'UYU', 'camionero'),
    ('claraisabelcanul18@gmail.com', '9c87400128d408cdcda0e4b3ff0e66fa', 'Clara', 'Isabel', 'Canul', 'Samano', '55447788', 'UYU', 'almacenero'),
    ('leonelsitopeñarol@gmail.com', '9c87400128d408cdcda0e4b3ff0e66fa', 'Ruben', 'Leonel', 'Guerrero', 'Bojorquez', '66558899', 'UYU', 'administrador');
INSERT INTO Almacen(descripcion, calle, nro_puerta, cod_postal, capacidad, departamento) VALUES
    ('Almacén de Colonia', 'Colonia', '1349', '11100', 50, 'colonia'),
    ('Almacén de San José', 'Calle Goes', '9876', '11600', 2000, 'san_jose'),
	('Almacén de Maldonado', 'Avenida Italia', '6543', '11400', 1500, 'maldonado'),
	('Almacén de Canelones', 'Bulevar Artigas', '8765', '11100', 1800, 'canelones');
INSERT INTO Cliente(nombre, calle, telefono) VALUES
	('CRECOM', 'Av. Libertador 7884', '095123456');
INSERT INTO UsuarioAlmacen(id_usuario, id_almacen) VALUES
	(2, 2);
INSERT INTO Paquete(id_externo, id_cliente, peso, dir_envio, estado) VALUES
	('4OQQDT4A94N3Y3C9XYCB', 1, 1.0, 'Francisco Llambí 1499, Montevideo, Uruguay', 'en_espera'),
    ('Q9J6O44M277ZQ9GR3TTI', 1, 7.2, 'Feliciano Rodríguez 2895, Montevideo, Uruguay', 'en_espera'),
    ('TRV24JGVL8JNKRRG24BS', 1, 2.2, 'Av. Luis Alberto de Herrera 7890, Montevideo, Uruguay', 'en_espera'),
	('ANHLCDPJ8ENCZNAY9UTR', 1, 3.5, 'Calle Colonia 5678, Montevideo, Uruguay', 'en_espera'),
	('2YA9XU6P95GHRRYBKUWX', 1, 1.0, 'Av. 8 de Octubre 1234, Montevideo, Uruguay', 'en_espera'),
	('XYHK9G2VDANYK847LSB7', 1, 4.0, 'Calle Uruguay 4321, Montevideo, Uruguay', 'en_espera'),
	('4CH5P26JWAW579AQQGBW', 1, 1.2, 'Av. Rivera 9876, Montevideo, Uruguay', 'en_espera'),
	('C8U5T87LSRDHE2T53MS6', 1, 0.5, 'Calle Bvar. Artigas 1111, Montevideo, Uruguay', 'en_espera'),
	('S7GQ9QYXAGXANFZLPFN9', 1, 2.8, 'Av. Luis Alberto de Herrera 2222, Montevideo, Uruguay', 'en_espera'),
	('9QBU2GSAD2B3G8KFXUBQ', 1, 5.0, 'Av. 18 de Julio 3333, Montevideo, Uruguay', 'en_espera'),
	('ZLE8X7AAZECAR9GPF599', 1, 2.1, 'Calle Colonia 4444, Montevideo, Uruguay', 'en_espera'),
	('E7L36ZYQ29YEM5ZVLLM7', 1, 0.7, 'Av. 8 de Octubre 5555, Montevideo, Uruguay', 'en_espera');
INSERT INTO Lote(id_almacen, estado) VALUES
	(1, 1),
    (1, 2),
    (1, 3);
INSERT INTO PaqueteLote(id_interno_paquete, id_lote, id_usuario) VALUES
	(1, 1, 2),
	(2, 1, 2),
	(3, 1, 2),
    (4, 1, 3),
    (5, 1, 2),
    (6, 2, 3),
	(7, 2, 3),
	(8, 2, 2),
    (9, 2, 3),
    (10, 2, 3),
    (11, 3, 3),
	(12, 3, 2),
	(5, 3, 2),
    (7, 3, 2),
    (3, 3, 2);
INSERT INTO Camion(marca, modelo, matricula, capacidad) VALUES
	('Volvo', 'VNL', 'XYZ 2015', 37.5),
    ('Freightliner', 'Cascadia', 'ABC 5723', 24.0),
    ('Kenworth', 'W900', 'DEF 3412', 24.0),
    ('Peterbilt', '389', 'GHI 8866', 37.5),
    ('Mack', 'Anthem', 'JKL 4567', 45.0);
INSERT INTO UsuarioCamion(id_usuario, id_camion) VALUES
	(2, 1);
INSERT INTO CamionEntradaSalida(id_camion, fecha_hora, tipo_operacion) VALUES
	(1, '2023-10-27 09:00:00', 'entrada'),
    (1, '2023-10-27 17:00:00', 'salida');
INSERT INTO CamionLote(id_camion, id_lote) VALUES
	(1, 1),
    (2, 2),
    (3, 3);