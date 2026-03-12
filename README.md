# Prueba Técnica - Practicante Desarrollo de Software (ASP.NET Core MVC)

Aplicación web sencilla que consume la API pública **JSONPlaceholder** para gestionar posts con operaciones CRUD.

## Funcionalidades implementadas

- Listar todos los posts (GET /posts)
- Ver detalle de un post (GET /posts/{id})
- Crear un nuevo post (POST /posts)
- Editar un post existente (PUT /posts/{id})
- Eliminar un post (DELETE /posts/{id})

## Tecnologías utilizadas

- ASP.NET Core MVC (.NET 10.0)
- HttpClient con inyección de dependencias (AddHttpClient)
- Async/await en todas las llamadas a la API
- Separación básica de responsabilidades: Controller → Service → Models
- Vistas Razor con Bootstrap
- Mensajes de éxito/error con TempData
- Validaciones básicas en formularios (opcional, si agregaste atributos DataAnnotations)

## Requisitos previos

- [.NET SDK 10.0](https://dotnet.microsoft.com/download) o superior
- Visual Studio Code (o Visual Studio)
- Git (para clonar el repositorio)

## Cómo ejecutar el proyecto (paso a paso)

### 1. Clonar el repositorio

git clone https://github.com/AbrahamVelazquez1/Prueba-vacante
cd prueba_vacante/prueba_vacante

### 2. Restaurar dependencias

dotnet restore

### 3. Compilar el proyecto

dotnet build

### 4. Ejecutar la aplicación

dotnet run

### 5. Abrir en el navegador

Una vez ejecutándose, abre tu navegador y navega a:
http://localhost:5011/Post

## Notas adicionales

- La API JSONPlaceholder simula las operaciones pero no persiste datos reales
- Al crear un post, siempre se retorna 'id = 101' como respuesta simulada
- Los mensajes de "simulado" indican que la operación fue procesada correctamente por la API fake