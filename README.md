## Instrucciones para correr el proyecto

1. Clona el repositorio.

2. Configura tu cadena de conexión en appsettings.json.
  - 2.1 En visual studio. Ver -> Explorador de servidores
  - 2.2 Hacer click derecho en "Conexiones de datos" y seleccionar "Crear nueva base de datos de SQL Server"
  - 2.3 Poner como nombre del servidor el nombre que aparezca en el SQL Server management studio y conectar.
  - 2.4 Una vez hecha la conexión, dar click en propiedades, ahí podrás ver la cadena de conexión
  - 2.5 en appsetting.json poner la cadena de conexión como valor de "DefaultConnectionString" : "aqui"

3. Ejecuta las migraciones:
  - En visual studio. Herramientas -> Administrador de Paquetes NuGet -> Consola del Administrador de Paquetes

4. Ejecutar lo siguiente en la consola:
  - 4.1 Add-Migration "Migracion Inicial" 
  - (una vez terminado el primer comando)
  - 4.2 update-database
   
5. Finalmente correr el proyecto
