# Instrucciones de Configuración y Ejecución

Este proyecto es una aplicación web para la administración de eventos, desarrollada con C#, .NET Framework 8.0, MySQL en el backend, y HTML, JavaScript y Bootstrap en el frontend. Sigue los pasos a continuación para configurar y ejecutar el sistema.

---

## 1. Requisitos Previos

Antes de comenzar, asegúrate de tener instalados los siguientes componentes en tu sistema:

### **Backend**
1. **.NET Framework 8.0 SDK**
   - Descárgalo desde: [https://dotnet.microsoft.com/](https://dotnet.microsoft.com/).

2. **MySQL Server**
   - Descárgalo desde: [https://dev.mysql.com/downloads/](https://dev.mysql.com/downloads/).

3. **Visual Studio 2022 o superior**
   - Con soporte para proyectos de .NET y C#.

### **Frontend**
1. Un navegador web moderno (Chrome, Edge, Firefox).
2. (Opcional) **Node.js** y el paquete `http-server` para servir los archivos HTML:
   ```bash
   npm install -g http-server
   ```

---

## 2. Configuración del Backend

### **Paso 1: Configurar la Base de Datos MySQL**

1. Inicia sesión en tu servidor MySQL.
2. Crea una base de datos llamada `EventosDB`:
   ```sql
   CREATE DATABASE EventosDB;
   ```
3. Usa el script `schema.sql` (proporcionado con el proyecto) para crear las tablas necesarias:
   ```sql
   USE EventosDB;

   CREATE TABLE Usuario (
       ID INT AUTO_INCREMENT PRIMARY KEY,
       Nombre VARCHAR(100),
       Correo VARCHAR(100) UNIQUE,
       Contraseña VARCHAR(100),
       RolID INT
   );

   CREATE TABLE Rol (
       ID INT AUTO_INCREMENT PRIMARY KEY,
       Nombre VARCHAR(50)
   );

   CREATE TABLE Evento (
       ID INT AUTO_INCREMENT PRIMARY KEY,
       Titulo VARCHAR(200),
       Descripcion TEXT,
       Lugar VARCHAR(200),
       Fecha DATETIME,
       UsuarioID INT
   );

   INSERT INTO Rol (Nombre) VALUES ('Admin'), ('Usuario');
   INSERT INTO Usuario (Nombre, Correo, Contraseña, RolID) VALUES ('Admin', 'admin@eventos.com', 'admin123', 1);
   ```

### **Paso 2: Configurar la Aplicación Backend**

1. Clona o descarga el proyecto.
2. Abre el archivo `appsettings.json` en el backend y configura la cadena de conexión a la base de datos:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=EventosDB;Uid=tu_usuario;Pwd=tu_contraseña;"
   }
   ```
3. Abre el proyecto en Visual Studio.
4. Restaura las dependencias ejecutando:
   ```bash
   dotnet restore
   ```
5. Ejecuta el backend:
   - Usa `dotnet run` desde la terminal o presiona `F5` en Visual Studio.
   - La API estará disponible en: `http://localhost:5000`.

---

## 3. Configuración del Frontend

### **Paso 1: Configurar el Frontend**
1. Navega al directorio `/Frontend` dentro del proyecto.
2. Asegúrate de que los archivos estén organizados como sigue:
   ```
   /Frontend
       ├── index.html
       ├── login.html
       ├── eventos.html
       ├── form-evento.html
       ├── css/
       └── js/
   ```

### **Paso 2: Servir los Archivos Frontend**

#### Opcion 1: Abrir directamente en el navegador
- Abre el archivo `login.html` en tu navegador web.

#### Opcion 2: Usar un servidor HTTP
1. Si tienes Node.js instalado, inicia un servidor en la carpeta `/Frontend`:
   ```bash
   http-server .
   ```
2. Accede a `http://localhost:8080` en tu navegador.

---

## 4. Uso del Sistema

### **Inicio de Sesión**
1. Ingresa con las credenciales iniciales:
   - Correo: `admin@eventos.com`
   - Contraseña: `admin123`

### **Administrar Eventos**
1. Una vez autenticado, serás redirigido a la lista de eventos (`eventos.html`).
2. Desde esta página puedes:
   - Crear nuevos eventos.
   - Editar eventos existentes.
   - Eliminar eventos.

---

## 5. Notas Adicionales
- **Seguridad Básica**: Este proyecto utiliza un método de autenticación básico. Las contraseñas no están cifradas en esta versión.
- **Depuración**: Si encuentras problemas, revisa la consola del navegador o los logs del backend en Visual Studio.
- **Extensiones Futuras**: Puedes mejorar este sistema agregando validaciones avanzadas, cifrado de contraseñas o diseños más elaborados.

---

## 6. Créditos
- **Desarrollador**: Joseph Fernando Ronces Noblecia 

