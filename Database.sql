Create database SAAE

Use SAAE 

drop table alumnos 

CREATE DATABASE SAAE;
GO

USE SAAE;
GO

/* =========================
   DROP SEGURO (OPCIONAL)
========================= */

IF OBJECT_ID('planeacion_valores') IS NOT NULL DROP TABLE planeacion_valores;
IF OBJECT_ID('planeaciones') IS NOT NULL DROP TABLE planeaciones;
IF OBJECT_ID('planeacion_campos') IS NOT NULL DROP TABLE planeacion_campos;
IF OBJECT_ID('planeacion_plantillas') IS NOT NULL DROP TABLE planeacion_plantillas;
IF OBJECT_ID('planeacion_layouts') IS NOT NULL DROP TABLE planeacion_layouts;

IF OBJECT_ID('entregas_tareas') IS NOT NULL DROP TABLE entregas_tareas;
IF OBJECT_ID('tareas') IS NOT NULL DROP TABLE tareas;

IF OBJECT_ID('participaciones') IS NOT NULL DROP TABLE participaciones;
IF OBJECT_ID('asistencias') IS NOT NULL DROP TABLE asistencias;

IF OBJECT_ID('alumnos') IS NOT NULL DROP TABLE alumnos;

IF OBJECT_ID('usuario_maestro') IS NOT NULL DROP TABLE usuario_maestro;
IF OBJECT_ID('usuario_roles') IS NOT NULL DROP TABLE usuario_roles;

IF OBJECT_ID('roles') IS NOT NULL DROP TABLE roles;
IF OBJECT_ID('usuarios') IS NOT NULL DROP TABLE usuarios;

IF OBJECT_ID('grupos') IS NOT NULL DROP TABLE grupos;
IF OBJECT_ID('escuelas') IS NOT NULL DROP TABLE escuelas;
IF OBJECT_ID('maestros') IS NOT NULL DROP TABLE maestros;

GO

/* =========================
   TABLAS BASE
========================= */

CREATE TABLE usuarios (
    id_usuario INT PRIMARY KEY IDENTITY(1,1),
    username VARCHAR(50) UNIQUE,
    password_hash VARCHAR(255),
    activo BIT DEFAULT 1
);

CREATE TABLE roles (
    id_rol INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(50)
);

CREATE TABLE escuelas (
    id_escuela INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(150) NOT NULL,
    direccion VARCHAR(MAX)
);

CREATE TABLE maestros (
    id_maestro INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100),
    apellido VARCHAR(100),
    email VARCHAR(150),
    telefono VARCHAR(20)
);

GO

/* =========================
   GRUPOS (DEPENDE DE BASE)
========================= */

CREATE TABLE grupos (
    id_grupo INT PRIMARY KEY IDENTITY(1,1),
    grado INT,
    grupo VARCHAR(10),
    turno VARCHAR(20) CHECK (turno IN ('matutino','vespertino')),
    id_escuela INT,
    id_maestro INT,
    creado_en DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (id_escuela) REFERENCES escuelas(id_escuela),
    FOREIGN KEY (id_maestro) REFERENCES maestros(id_maestro)
);

GO

/* =========================
   USUARIO RELACIONES
========================= */

CREATE TABLE usuario_roles (
    id_usuario INT,
    id_rol INT,

    FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario),
    FOREIGN KEY (id_rol) REFERENCES roles(id_rol)
);

CREATE TABLE usuario_maestro (
    id_usuario INT,
    id_maestro INT,

    FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario),
    FOREIGN KEY (id_maestro) REFERENCES maestros(id_maestro)
);

GO

/* =========================
   ALUMNOS
========================= */

CREATE TABLE alumnos (
    id_alumno INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    fecha_nacimiento DATE,
    genero VARCHAR(20),
    email VARCHAR(150),
    telefono VARCHAR(20),
    direccion VARCHAR(MAX),
    id_grupo INT,
    fecha_registro DATETIME DEFAULT GETDATE(),
    activo BIT DEFAULT 1,

    FOREIGN KEY (id_grupo) REFERENCES grupos(id_grupo)
);

GO

/* =========================
   ASISTENCIA Y PARTICIPACIÓN
========================= */

CREATE TABLE asistencias (
    id_asistencia INT PRIMARY KEY IDENTITY(1,1),
    id_alumno INT NOT NULL,
    fecha DATE NOT NULL,
    estado VARCHAR(20) CHECK (estado IN ('presente', 'ausente', 'retardo', 'justificado')),
    observaciones VARCHAR(MAX),

    FOREIGN KEY (id_alumno) REFERENCES alumnos(id_alumno)
);

CREATE TABLE participaciones (
    id_participacion INT PRIMARY KEY IDENTITY(1,1),
    id_alumno INT NOT NULL,
    fecha DATE NOT NULL,
    descripcion VARCHAR(MAX),
    puntos INT DEFAULT 0,

    FOREIGN KEY (id_alumno) REFERENCES alumnos(id_alumno)
);

GO

/* =========================
   TAREAS
========================= */

CREATE TABLE tareas (
    id_tarea INT PRIMARY KEY IDENTITY(1,1),
    titulo VARCHAR(200) NOT NULL,
    descripcion VARCHAR(MAX),
    fecha_asignacion DATE,
    fecha_entrega DATE,
    puntos_maximos INT,
    creada_en DATETIME DEFAULT GETDATE()
);

CREATE TABLE entregas_tareas (
    id_entrega INT PRIMARY KEY IDENTITY(1,1),
    id_tarea INT NOT NULL,
    id_alumno INT NOT NULL,
    fecha_entrega DATE,
    calificacion INT,
    estado VARCHAR(20) CHECK (estado IN ('entregado', 'no_entregado', 'tarde')),
    comentarios VARCHAR(MAX),

    FOREIGN KEY (id_tarea) REFERENCES tareas(id_tarea),
    FOREIGN KEY (id_alumno) REFERENCES alumnos(id_alumno)
);

GO

/* =========================
   PLANEACIÓN
========================= */

CREATE TABLE planeacion_layouts (
    id_layout INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(150),
    archivo_nombre VARCHAR(255),
    contenido VARCHAR(MAX),
    creada_en DATETIME DEFAULT GETDATE()
);

CREATE TABLE planeacion_plantillas (
    id_plantilla INT PRIMARY KEY IDENTITY(1,1),
    id_layout INT,
    nombre VARCHAR(150),
    descripcion VARCHAR(MAX),
    creada_en DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (id_layout) REFERENCES planeacion_layouts(id_layout)
);

CREATE TABLE planeacion_campos (
    id_campo INT PRIMARY KEY IDENTITY(1,1),
    id_plantilla INT,
    nombre_campo VARCHAR(100),
    tipo VARCHAR(50),
    requerido BIT DEFAULT 0,
    orden INT,

    FOREIGN KEY (id_plantilla) REFERENCES planeacion_plantillas(id_plantilla)
);

CREATE TABLE planeaciones (
    id_planeacion INT PRIMARY KEY IDENTITY(1,1),
    id_plantilla INT,
    titulo VARCHAR(200),
    fecha DATE,
    creada_en DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (id_plantilla) REFERENCES planeacion_plantillas(id_plantilla)
);

CREATE TABLE planeacion_valores (
    id_valor INT PRIMARY KEY IDENTITY(1,1),
    id_planeacion INT,
    id_campo INT,
    valor VARCHAR(MAX),

    FOREIGN KEY (id_planeacion) REFERENCES planeaciones(id_planeacion),
    FOREIGN KEY (id_campo) REFERENCES planeacion_campos(id_campo)
);

GO


select * from usuarios

-- Insertar un usuario de prueba (usuario: admin, contraseña: admin123)
-- El hash corresponde a SHA256 de "admin123"
IF NOT EXISTS (SELECT * FROM usuarios WHERE username = 'admin')
BEGIN
    INSERT INTO usuarios (username, password_hash, activo)
    VALUES ('admin', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 1);
END
GO

