-- Script de ayuda para insertar usuarios con contraseñas hasheadas
-- Usa este template para agregar nuevos usuarios al sistema

USE SAAE;
GO

-- IMPORTANTE: Las contraseñas deben estar hasheadas con SHA256
-- Puedes usar la función CreateUser del AuthenticationService para crear usuarios desde código
-- O usar una herramienta online para generar el hash SHA256 de tu contraseña

-- Template para insertar nuevo usuario:
-- INSERT INTO usuarios (username, password_hash, activo)
-- VALUES ('nombre_usuario', 'hash_sha256_de_la_contraseña', 1);

-- Ejemplos de hashes SHA256 para contraseñas comunes (SOLO PARA DESARROLLO):
-- "admin123" -> 240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9
-- "maestro123" -> ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f
-- "password" -> 5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8
-- "12345" -> 5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5

-- Para generar un hash SHA256:
-- 1. Ve a: https://emn178.github.io/online-tools/sha256.html
-- 2. Ingresa tu contraseña
-- 3. Copia el hash generado (en minúsculas)
-- 4. Úsalo en el INSERT

-- Ejemplo: Crear usuario "profesor" con contraseña "profe2026"
-- Primero genera el hash de "profe2026", luego ejecuta:
-- INSERT INTO usuarios (username, password_hash, activo)
-- VALUES ('profesor', 'tu_hash_aqui', 1);

-- Consultar todos los usuarios
SELECT id_usuario, username, activo, 
       CASE WHEN activo = 1 THEN 'Activo' ELSE 'Inactivo' END as estado
FROM usuarios;
GO

-- Desactivar un usuario (sin eliminarlo)
-- UPDATE usuarios SET activo = 0 WHERE username = 'nombre_usuario';

-- Reactivar un usuario
-- UPDATE usuarios SET activo = 1 WHERE username = 'nombre_usuario';

-- Cambiar contraseña de un usuario
-- UPDATE usuarios SET password_hash = 'nuevo_hash_sha256' WHERE username = 'nombre_usuario';
