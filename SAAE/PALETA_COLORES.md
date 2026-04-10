# 🎨 Paleta de Colores - Sistema SAAE

## Estilo: Oscuro Moderno

### 📐 Colores Principales

#### **Panel Lateral (Menú de Navegación)**
```csharp
Color.FromArgb(45, 52, 62)
```
- **Hex**: `#2D343E`
- **RGB**: `45, 52, 62`
- **Descripción**: Gris azulado oscuro, elegante y profesional
- **Uso**: Fondo del panel lateral izquierdo

#### **Panel de Contenido (Área de Trabajo)**
```csharp
Color.FromArgb(245, 247, 250)
```
- **Hex**: `#F5F7FA`
- **RGB**: `245, 247, 250`
- **Descripción**: Gris azulado muy claro, suave para la vista
- **Uso**: Fondo del área principal donde se muestra el Dashboard y otros módulos

### 🎯 Colores de Acento

#### **Color Acento Principal (Coral)**
```csharp
Color.FromArgb(255, 127, 80)
```
- **Hex**: `#FF7F50`
- **RGB**: `255, 127, 80`
- **Descripción**: Coral vibrante, combina con el logo de la manzana
- **Uso**: Botón presionado (MouseDown), elementos activos

#### **Color Hover (Gris Medio)**
```csharp
Color.FromArgb(60, 70, 85)
```
- **Hex**: `#3C4655`
- **RGB**: `60, 70, 85`
- **Descripción**: Gris azulado medio
- **Uso**: Efecto hover sobre botones del menú

### 📝 Colores de Texto

#### **Texto Principal en Panel Oscuro**
```csharp
Color.FromArgb(220, 220, 220)
```
- **Hex**: `#DCDCDC`
- **RGB**: `220, 220, 220`
- **Descripción**: Gris claro, alto contraste sobre fondo oscuro
- **Uso**: Texto de botones en estado normal

#### **Texto Hover**
```csharp
Color.White
```
- **Hex**: `#FFFFFF`
- **RGB**: `255, 255, 255`
- **Descripción**: Blanco puro
- **Uso**: Texto de botones al pasar el cursor

#### **Texto Copyright**
```csharp
Color.FromArgb(100, 100, 100)
```
- **Hex**: `#646464`
- **RGB**: `100, 100, 100`
- **Descripción**: Gris medio
- **Uso**: Label de copyright (esquina inferior derecha)

## 🎭 Efectos Visuales

### **Botones del Menú**

#### Estado Normal
- Fondo: Transparente
- Texto: `#DCDCDC` (Gris claro)
- Borde: Sin borde

#### Estado Hover (Mouse Over)
- Fondo: `#3C4655` (Gris medio)
- Texto: `#FFFFFF` (Blanco)
- Cursor: Mano (Hand)

#### Estado Presionado (Mouse Down)
- Fondo: `#FF7F50` (Coral)
- Texto: `#FFFFFF` (Blanco)

## 🖼️ Ejemplo Visual

```
┌─────────────────────────────────────────────────────────┐
│  ┏━━━━━━━━━┓  ┌─────────────────────────────────────┐  │
│  ┃         ┃  │                                     │  │
│  ┃  LOGO   ┃  │         Panel de Contenido          │  │
│  ┃  SAAE   ┃  │       (Gris azulado claro)         │  │
│  ┗━━━━━━━━━┛  │         #F5F7FA                     │  │
│  ┏━━━━━━━━━┓  │                                     │  │
│  ┃Asistenc.┃  │                                     │  │
│  ┃Particip.┃  │                                     │  │
│  ┃Alumnos  ┃  │                                     │  │
│  ┃Activids.┃  │                                     │  │
│  ┃Tareas   ┃  │                                     │  │
│  ┃Config   ┃  │                                     │  │
│  ┃Cerrar   ┃  │                                     │  │
│  ┗━━━━━━━━━┛  └─────────────────────────────────────┘  │
│  Panel Lateral                             @Copyright   │
│  (Gris oscuro)                                          │
│    #2D343E                                              │
└─────────────────────────────────────────────────────────┘
```

## 🎨 Complementos de Color (Para Futuras Funcionalidades)

### **Colores de Estado**

#### Éxito (Success)
```csharp
Color.FromArgb(46, 204, 113)  // Verde #2ECC71
```

#### Advertencia (Warning)
```csharp
Color.FromArgb(241, 196, 15)  // Amarillo #F1C40F
```

#### Error (Danger)
```csharp
Color.FromArgb(231, 76, 60)  // Rojo #E74C3C
```

#### Información (Info)
```csharp
Color.FromArgb(52, 152, 219)  // Azul #3498DB
```

## 📱 Accesibilidad

### **Contraste de Colores**

| Combinación | Contraste | WCAG AA | WCAG AAA |
|-------------|-----------|---------|----------|
| `#DCDCDC` sobre `#2D343E` | 8.5:1 | ✅ Pasa | ✅ Pasa |
| `#FFFFFF` sobre `#2D343E` | 11.2:1 | ✅ Pasa | ✅ Pasa |
| `#646464` sobre `#F5F7FA` | 4.6:1 | ✅ Pasa | ⚠️ No pasa |

## 🔧 Implementación en Código

### **Aplicar colores principales**
```csharp
// Panel Lateral
_sidePanel.BackColor = Color.FromArgb(45, 52, 62);

// Panel de Contenido
_contentPanel.BackColor = Color.FromArgb(245, 247, 250);

// Texto de botones
button.ForeColor = Color.FromArgb(220, 220, 220);

// Efectos hover
button.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 70, 85);
button.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 127, 80);
```

## 📊 Paleta Completa (Referencia Rápida)

| Nombre | RGB | Hex | Uso |
|--------|-----|-----|-----|
| Oscuro Principal | 45, 52, 62 | #2D343E | Panel lateral |
| Claro Principal | 245, 247, 250 | #F5F7FA | Panel contenido |
| Coral Acento | 255, 127, 80 | #FF7F50 | Botón activo |
| Hover Oscuro | 60, 70, 85 | #3C4655 | Hover botones |
| Texto Claro | 220, 220, 220 | #DCDCDC | Texto normal |
| Blanco | 255, 255, 255 | #FFFFFF | Texto hover |
| Gris Medio | 100, 100, 100 | #646464 | Texto secundario |

---

**Nota**: Esta paleta está optimizada para ser profesional, moderna y fácil de ver durante largas sesiones de trabajo. Los colores combinan perfectamente con el logo SAAE (manzana coral).

**Autor**: Javier Nieto - 2026  
**Proyecto**: SAAE - Sistema Automatizado de Asistencia Escolar
