Repositorio codigo
-----------------------------------------------------
https://github.com/chuflay29/M7G2Tarea1/tree/Api2

Requerimientos tecnicos servidor Jenkins
--------------------------------------------------
Sistema Operativo windows 10 pro 

- .NET sdk version 8.0.403
- .Net runtime hosting bundle 8.0.10
- Nuget Packages
	- Microsoft.EntityFrameworkCore version 8.0.8
	- Microsoft.EntityFrameworkCore.Tools version 8.0.8
	- Microsoft.EntityFrameworkCore.SqlServer version 8.0.8
	- System.Linq.Dynamic.Core version 1.4.5
	- xunit version 2.5.3
	
- NodeJS version 20.13.1 con npm 10.5.2
- Angular version 17.0.3
- angular material version 17.0.3

- Visual Studio Comunity 2022 version 17.11.5


Requerimientos Servidor Web Producción 
---------------------------------------------------------
- .NET runtime version 8.0.403
- SQL Server Express 2022 version 16.0.1130
	puerto por defecto 1433
- IIS web server version 10.0.19041.4522
	aplicacion web
		puerto: 8090
	aplicacion API
		puerto: 8091
	

Base de Datos
--------------------------------------------------------------
nombre Base de Datos: M7G2

Configuración Aplicacion API
---------------------------------------------------------
appsettings.json
	- en la cadena de conexion a la BD, cambiar el nombre del server, el nombre de la instancia de la BD, el user y el Password
		Server=localhost\\SQLEXPRESS;Database=M7G2;User Id=sa;Password=pass
		
