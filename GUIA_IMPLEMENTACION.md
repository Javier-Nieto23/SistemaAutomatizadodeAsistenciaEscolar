# Guía de Implementación - Sistema SAAE

## ✅ Lo que se ha implementado

### 1. Estructura de Carpetas
```
SAAE/
├── cnx/                          # Conexión y configuración
│   ├── DatabaseConnection.cs    # Manejo de conexiones a SQL Server
│   └── AppConfig.cs             # Configuración centralizada
│
├── methods/                      # Lógica de negocio
│   └── AuthenticationService.cs # Autenticación y validación
│
├── SQL/                          # Scripts de base de datos
│   ├── CreateDatabase.sql       # Creación de BD y usuarios de prueba
│   └── InsertUserHelper.sql     # Guía para insertar usuarios
│
└── Forms/                        # Formularios de Windows Forms
    ├── Form1.cs                 # Login
    ├── PanelFormulario.cs       # Panel principal
    └── Dashboard.cs             # Dashboard de trabajo
```

### 2. Clase DatabaseConnection (cnx/DatabaseConnection.cs)

**Características:**
- Constructor que obtiene la cadena de conexión desde AppConfig
- Método `GetConnection()` para obtener una conexión SQL
- Método `TestConnection()` para verificar la conectividad
- Manejo de excepciones descriptivo

**Uso:**
```csharp
var dbConnection = new DatabaseConnection();
using (SqlConnection conn = dbConnection.GetConnection())
{
    conn.Open();
    // Tu código aquí
}
```

### 3. Clase AuthenticationService (methods/AuthenticationService.cs)

**Características:**
- Constructor que inicializa DatabaseConnection
- `ValidateUser(username, password)`: Valida credenciales
- `HashPassword(password)`: Genera hash SHA256
- `CreateUser(username, password)`: Crea nuevos usuarios
- Verifica que usuarios estén activos
- Manejo completo de excepciones

**Uso:**
```csharp
var authService = new AuthenticationService();
if (authService.ValidateUser("admin", "admin123"))
{
    // Usuario válido
}
```

### 4. Clase AppConfig (cnx/AppConfig.cs)

**Características:**
- Configuración centralizada de la aplicación
- Tres secciones principales:
  - `Database`: Parámetros de conexión
  - `Application`: Información de la app
  - `Security`: Configuraciones de seguridad

**Uso:**
```csharp
string connectionString = AppConfig.Database.GetConnectionString();
string appName = AppConfig.Application.Name;
int maxAttempts = AppConfig.Security.MaxLoginAttempts;
```

### 5. Form1 - Formulario de Login

**Características:**
- Se centra automáticamente en la pantalla
- Campo de contraseña oculto
- Validación al presionar Enter
- Botón "Ingresar" que valida credenciales
- Botón "Salir" con confirmación
- Cierra el formulario al autenticarse exitosamente
- Abre PanelFormulario después del login

**Campos:**
- `textBox1`: Usuario
- `textBox2`: Contraseña (tipo password)
- `button1`: Botón "Ingresar"
- `button2`: Botón "Salir"

### 6. PanelFormulario - Panel Principal

**Características:**
- Se maximiza automáticamente al abrir
- Muestra formularios hijos dentro (patrón MDI simulado)
- Panel de contenido dinámico
- Redimensionamiento automático de componentes
- Confirmación antes de cerrar
- Carga automáticamente el Dashboard al iniciar

**Funcionalidades:**
- `OpenChildForm(Form)`: Abre un formulario dentro del panel
- `ShowDashboard()`: Muestra el Dashboard
- Ajuste automático de controles al redimensionar

### 7. Dashboard - Panel de Trabajo

**Características:**
- Se muestra dentro de PanelFormulario
- Preparado para agregar módulos del sistema
- Base para planeaciones, asistencia, participación, etc.

## 🔧 Configuración de Base de Datos

### Estructura de la Tabla Usuarios

```sql
CREATE TABLE usuarios (
    id_usuario INT PRIMARY KEY IDENTITY(1,1),
    username VARCHAR(50) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    activo BIT DEFAULT 1
);
```

### Usuarios de Prueba Creados

| Usuario | Contraseña  | Estado |
|---------|-------------|--------|
| admin   | admin123    | Activo |
| maestro | maestro123  | Activo |

### Pasos para Configurar

1. Abre SQL Server Management Studio o Azure Data Studio
2. Conéctate a: `MAM-IVT-PC-13\SQLEXPRESS`
3. Ejecuta el script: `SAAE\SQL\CreateDatabase.sql`
4. Verifica que la tabla se creó: `SELECT * FROM SAAE.dbo.usuarios;`

## 🚀 Cómo Ejecutar el Sistema

### Paso 1: Verificar Base de Datos
```sql
USE SAAE;
SELECT * FROM usuarios;
```

### Paso 2: Compilar y Ejecutar
1. Abre la solución en Visual Studio
2. Presiona F6 para compilar
3. Presiona F5 para ejecutar
4. Aparecerá Form1 (Login)

### Paso 3: Iniciar Sesión
1. Usuario: `admin`
2. Contraseña: `admin123`
3. Click en "Ingresar" o presiona Enter
4. Se abrirá PanelFormulario con Dashboard

## 📝 Flujo del Sistema

```
1. Aplicación inicia
   ↓
2. Form1 (Login) se muestra centrado
   ↓
3. Usuario ingresa credenciales
   ↓
4. AuthenticationService valida contra BD
   ↓
5. Si es válido:
   - Form1 se oculta
   - PanelFormulario se abre maximizado
   - Dashboard se carga dentro de PanelFormulario
   ↓
6. Usuario trabaja en el sistema
   ↓
7. Al cerrar PanelFormulario:
   - Solicita confirmación
   - Cierra toda la aplicación
```

## 🔒 Seguridad Implementada

1. **Contraseñas Hasheadas**: Usando SHA256
2. **Validación de Usuarios Activos**: Solo usuarios con `activo = 1`
3. **Parametrización SQL**: Previene inyección SQL
4. **Manejo de Excepciones**: Mensajes descriptivos sin exponer detalles técnicos
5. **Campo de Contraseña Oculto**: `PasswordChar = '*'`

## 🎨 Características de UI

1. **Formularios Centrados**: `StartPosition.CenterScreen`
2. **Maximización Automática**: PanelFormulario se maximiza
3. **Redimensionamiento Dinámico**: Los controles se ajustan al tamaño de ventana
4. **Formularios Anidados**: Dashboard dentro de PanelFormulario
5. **Confirmaciones**: Al cerrar y salir del sistema

## 📦 Paquetes NuGet Instalados

- **Microsoft.Data.SqlClient** (v7.0.0): Para conexión con SQL Server

## 🔄 Próximas Características a Implementar

1. ✅ Sistema de login
2. ✅ Conexión a base de datos
3. ✅ Panel principal con Dashboard
4. ⏳ Módulo de Planeaciones
5. ⏳ Registro de Asistencia
6. ⏳ Seguimiento de Participación
7. ⏳ Gestión de Tareas
8. ⏳ Administración de Grupos
9. ⏳ Administración de Alumnos

## 💡 Tips para Desarrollo

### Agregar Nuevos Usuarios desde Código

```csharp
var authService = new AuthenticationService();
try
{
    bool created = authService.CreateUser("nuevo_usuario", "contraseña");
    if (created)
    {
        MessageBox.Show("Usuario creado exitosamente");
    }
}
catch (Exception ex)
{
    MessageBox.Show($"Error: {ex.Message}");
}
```

### Abrir un Nuevo Formulario en PanelFormulario

```csharp
// Desde PanelFormulario
MiNuevoForm nuevoForm = new MiNuevoForm();
OpenChildForm(nuevoForm);
```

### Cambiar Configuración de Base de Datos

Edita `SAAE\cnx\AppConfig.cs`:
```csharp
public const string Server = "TU_SERVIDOR";
public const string DatabaseName = "TU_BD";
```

## 🐛 Solución de Problemas

### Error de Conexión a Base de Datos
1. Verifica que SQL Server esté corriendo
2. Verifica el nombre del servidor en AppConfig.cs
3. Verifica las credenciales (usuario/contraseña)
4. Asegúrate de que la base de datos SAAE existe

### No Puede Iniciar Sesión
1. Verifica que el usuario existe: `SELECT * FROM usuarios WHERE username = 'admin'`
2. Verifica que el usuario está activo: `activo = 1`
3. Verifica el hash de la contraseña

### Formulario No Se Muestra Dentro del Panel
1. Verifica que el formulario hijo tiene `TopLevel = false`
2. Verifica que `FormBorderStyle = None`
3. Verifica que `Dock = Fill`

## 📞 Contacto

**Desarrollador**: Javier Nieto  
**Año**: 2026  
**Proyecto**: SAAE - Sistema Automatizado de Asistencia Escolar

---

**Nota**: Este sistema está en desarrollo activo. Las características se irán agregando progresivamente según las necesidades del proyecto.
