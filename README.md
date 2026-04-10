# Sistema SAAE - Sistema Automatizado de Asistencia Escolar

## Descripción
Sistema RDP para maestros que ayuda a crear planeaciones, registrar asistencia de alumnos, participación, tareas y administrar grupos.

## Características Implementadas

### 1. Conexión a Base de Datos
- **Ubicación**: `SAAE\cnx\DatabaseConnection.cs`
- **Servidor**: MAM-IVT-PC-13\SQLEXPRESS
- **Base de Datos**: SAAE
- **Autenticación**: SQL Server (usuario: sa)

### 2. Servicio de Autenticación
- **Ubicación**: `SAAE\methods\AuthenticationService.cs`
- **Características**:
  - Validación de usuarios con contraseñas hasheadas (SHA256)
  - Verificación de usuarios activos
  - Creación de nuevos usuarios
  - Encapsulamiento completo de lógica de negocio

### 3. Formulario de Login (Form1)
- **Características**:
  - Centrado en pantalla automáticamente
  - Validación de credenciales
  - Campo de contraseña oculto
  - Soporte para Enter key
  - Botón "Ingresar" para validar sesión
  - Botón "Salir" para cerrar el sistema
  - Cierra automáticamente después de login exitoso

### 4. Panel Principal (PanelFormulario)
- **Características**:
  - Maximizado automáticamente
  - Muestra formularios hijos dentro (Dashboard)
  - Redimensionamiento automático de componentes
  - Confirmación antes de cerrar sesión

### 5. Dashboard
- Formulario que se muestra dentro de PanelFormulario
- Preparado para agregar funcionalidades de planeación, asistencia, etc.

## Configuración Inicial

### 1. Configurar Base de Datos

Ejecuta el script SQL ubicado en `SAAE\SQL\CreateDatabase.sql` en SQL Server Management Studio o Azure Data Studio.

El script creará:
- Base de datos SAAE
- Tabla usuarios con campos: id_usuario, username, password_hash, activo
- Usuario de prueba: 
  - **Usuario**: admin
  - **Contraseña**: admin123

### 2. Ejecutar el Proyecto

1. Abre la solución en Visual Studio
2. Compila el proyecto (Ctrl+Shift+B)
3. Ejecuta el proyecto (F5)
4. Ingresa con las credenciales de prueba

## Estructura del Proyecto

```
SAAE/
├── cnx/
│   └── DatabaseConnection.cs       # Conexión a base de datos
├── methods/
│   └── AuthenticationService.cs    # Servicios de autenticación
├── SQL/
│   └── CreateDatabase.sql          # Script de creación de BD
├── Form1.cs                        # Formulario de login
├── PanelFormulario.cs              # Panel principal
└── Dashboard.cs                    # Dashboard principal
```

## Tecnologías Utilizadas

- **.NET 10**
- **C# 14.0**
- **Windows Forms**
- **Microsoft.Data.SqlClient** (7.0.0)
- **SQL Server**

## Próximos Pasos

1. Implementar módulo de planeaciones
2. Implementar registro de asistencia
3. Implementar seguimiento de participación
4. Implementar gestión de tareas
5. Implementar administración de grupos y alumnos

## Notas Técnicas

- El sistema aplica encapsulamiento para mejor mantenibilidad
- Las contraseñas se almacenan hasheadas con SHA256
- Los formularios se muestran dentro de otros para ahorrar recursos
- El sistema valida usuarios activos/inactivos
- Maneja excepciones y muestra mensajes descriptivos al usuario

## Autor
Javier Nieto - 2026
