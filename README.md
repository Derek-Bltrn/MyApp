## Instrucciones para correr el proyecto

1. Clona el repositorio.

2. Configura tu cadena de conexión en appsettings.json.
  - 2.1 En visual studio. Ver -> Explorador de servidores
  - 2.2 Hacer click derecho en "Conexiones de datos" y seleccionar "Crear nueva base de datos de SQL Server"
  - 2.3 Poner como nombre del servidor el nombre que aparezca en el SQL Server management studio y conectar.
  - 2.4 Una vez hecha la conexión, dar click en propiedades, ahí podrás ver la cadena de conexión
  - 2.5 en appsetting.json poner la cadena de conexión como valor de "DefaultConnectionString" : "aqui"

3. Ejecuta las migraciones:
  - 3.1 En visual studio. Herramientas -> Administrador de Paquetes NuGet -> Consola del Administrador de Paquetes
  - (Ejecutar lo siguiente en la consola del administrador de paquetes)
  - 3.2 Add-Migration "Migracion Inicial" 
  - (una vez terminado el primer comando)
  - 3.3 update-database
   
4. Finalmente correr el proyecto
