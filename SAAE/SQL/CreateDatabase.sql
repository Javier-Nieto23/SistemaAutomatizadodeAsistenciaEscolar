-- Script para crear la base de datos SAAE y la tabla de usuarios

USE master;
GO

-- Crear la base de datos si no existe
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'SAAE')
BEGIN
    CREATE DATABASE SAAE;
END
GO

USE SAAE;
GO

-- Crear la tabla de usuarios si no existe
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'usuarios')
BEGIN
    CREATE TABLE usuarios (
        id_usuario INT PRIMARY KEY IDENTITY(1,1),
        username VARCHAR(50) UNIQUE NOT NULL,
        password_hash VARCHAR(255) NOT NULL,
        activo BIT DEFAULT 1
    );
END
GO

-- Insertar un usuario de prueba (usuario: admin, contraseña: admin123)
-- El hash corresponde a SHA256 de "admin123"
IF NOT EXISTS (SELECT * FROM usuarios WHERE username = 'admin')
BEGIN
    INSERT INTO usuarios (username, password_hash, activo)
    VALUES ('admin', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 1);
END
GO

-- Insertar otro usuario de prueba (usuario: maestro, contraseña: maestro123)
-- El hash corresponde a SHA256 de "maestro123"
IF NOT EXISTS (SELECT * FROM usuarios WHERE username = 'maestro')
BEGIN
    INSERT INTO usuarios (username, password_hash, activo)
    VALUES ('maestro', 'ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f', 1);
END
GO

SELECT * FROM usuarios;
GO
