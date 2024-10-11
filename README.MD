 Herramientas Necesarias:
DBeaver: 
motor de bases de datos PostgreSQL.
Docker: 
Docker instalado para ejecutar contenedores, incluyendo PostgreSQL.

 clonar https://github.com/Arlex0296/PruebaHgi.git
Configurar la Conexión a la Base de Datos:
 appsettings.json 


Migrar la Base de Datos Usando Entity Framework Core:
dotnet ef migrations add InitialCreate
dotnet ef database update


Ejecutar el Proyecto:
dotnet run

Abre Postman y realiza peticiones HTTP a las rutas de tu API 
utilizando el puerto que tu aplicación esté utilizando (por defecto, es el 5000 o 5001 para HTTPS).