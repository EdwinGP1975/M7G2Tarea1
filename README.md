Repositorio codigo
-----------------------------------------------------
https://github.com/chuflay29/M7G2Tarea1/tree/Api2

Requerimientos tecnicos servidor Jenkins
--------------------------------------------------
- Sistema Operativo windows 10 pro 
- .NET sdk version 8.0.403
- .NET runtime hosting bundle 8.0.10
- Nuget Packages
	- Microsoft.EntityFrameworkCore version 8.0.8
	- Microsoft.EntityFrameworkCore.Tools version 8.0.8
	- Microsoft.EntityFrameworkCore.SqlServer version 8.0.8
	- System.Linq.Dynamic.Core version 1.4.5
	- xunit version 2.5.3	
- NodeJS version 20.13.1 con npm 10.5.2
- Angular version 17.0.3
- Angular material version 17.0.3
- Visual Studio Comunity 2022 version 17.11.5


Requerimientos Servidor Web Producción 
---------------------------------------------------------
- .NET runtime version 8.0.403
- SQL Server Express 2022 version 16.0.1130
	puerto por defecto 1433
- IIS web server version 10.0.19041.4522

Configuración Inicial de la Base de Datos:
--------------------------------------------------------------
 
- Para Crear la Base datos Ejecutar el Script: M7G2_B2_Initial_script.sql
- El Nombre Base de Datos será: M7G2
- Crear el Login: usrventas, con password: UsrVentas2024!
- Asignar permisos de Owner sobre la base de datos M7G2

Configuración Inicial del Sitio en IIS para la API:
--------------------------------------------------------------
- Crear la Carpeta "ApiVentas" en C:\inetpub\wwwroot\ApiVentas
- Proporcionar permisos de control total sobre la carpeta "ApiVentas", al Usuario IIS_IUSRS
- En IIS, crear un Sitio: ApiVentas
- Direccionar a la Carpeta: C:\inetpub\wwwroot\ApiVentas
- Asignar el puerto 8091


Configuración Inicial del Sitio en IIS para la API:
--------------------------------------------------------------
- Crear la Carpeta "ApiVentas" en C:\inetpub\wwwroot\WebVentas
- Proporcionar permisos de control total sobre la carpeta "WebVentas", al Usuario IIS_IUSRS
- En IIS, crear un Sitio: WebVentas
- Direccionar a la Carpeta: C:\inetpub\wwwroot\WebVentas
- Asignar el puerto 8091

Configuración del appsettings.json, para la API:
---------------------------------------------------------
- Abrir el archivo appsettings.json
- En la cadena de conexion a la BD, cambiar el nombre del server, el nombre de la instancia de la BD, el user y el Password
   Server=localhost\\SQLEXPRESS;Database=M7G2;User Id=usrventas;Password=UsrVentas2024!
		
