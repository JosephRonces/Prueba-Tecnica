CREATE DATABASE EventManagement;

USE EventManagement;

-- Tabla Rol
CREATE TABLE Rol (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL
);

-- Tabla Usuario
CREATE TABLE Usuario (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Correo VARCHAR(100) UNIQUE NOT NULL,
    Contraseña VARCHAR(100) NOT NULL,
    RolID INT NOT NULL,
    FOREIGN KEY (RolID) REFERENCES Rol(ID)
);

-- Tabla Evento
CREATE TABLE Evento (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Titulo VARCHAR(200) NOT NULL,
    Descripcion TEXT NOT NULL,
    Lugar VARCHAR(200) NOT NULL,
    Fecha DATETIME NOT NULL,
    UsuarioID INT NOT NULL,
    FOREIGN KEY (UsuarioID) REFERENCES Usuario(ID)
);

-- Insertar roles iniciales
INSERT INTO Rol (Nombre) VALUES ('Administrador'), ('Usuario');

-- Insertar usuario inicial
INSERT INTO Usuario (Nombre, Correo, Contraseña, RolID)
VALUES ('Admin', 'admin@eventos.com', 'admin123', 1);

