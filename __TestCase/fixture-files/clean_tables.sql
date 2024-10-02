delete VentaDetalle
delete Ventas
delete Productos
delete GrupoProductos
delete Fabricantes
delete Proveedores
delete GrupoCliente
delete Personas
DBCC CHECKIDENT (VentaDetalle, RESEED,1)
DBCC CHECKIDENT (Ventas, RESEED,1)
DBCC CHECKIDENT (GrupoCliente, RESEED,1)
DBCC CHECKIDENT (Fabricantes, RESEED,1)
DBCC CHECKIDENT (GrupoProductos, RESEED,1)
DBCC CHECKIDENT (Productos, RESEED,1)
DBCC CHECKIDENT (Proveedores, RESEED,1)
