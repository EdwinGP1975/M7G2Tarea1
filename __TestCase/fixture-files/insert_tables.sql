SET IDENTITY_INSERT [dbo].[Fabricantes] ON 
INSERT [dbo].[Fabricantes] ([Id], [cNmbFabricante]) VALUES (1, N'DELL')
INSERT [dbo].[Fabricantes] ([Id], [cNmbFabricante]) VALUES (2, N'HP')
INSERT [dbo].[Fabricantes] ([Id], [cNmbFabricante]) VALUES (3, N'MSI')
INSERT [dbo].[Fabricantes] ([Id], [cNmbFabricante]) VALUES (4, N'PRUEBA')
SET IDENTITY_INSERT [dbo].[Fabricantes] OFF
SET IDENTITY_INSERT [dbo].[GrupoProductos] ON 
INSERT [dbo].[GrupoProductos] ([Id], [cCodGrupoProducto], [cNombreGrupoProducto]) VALUES (1, N'1001', N'Computadoras')
INSERT [dbo].[GrupoProductos] ([Id], [cCodGrupoProducto], [cNombreGrupoProducto]) VALUES (2, N'1002', N'Accesorios')
INSERT [dbo].[GrupoProductos] ([Id], [cCodGrupoProducto], [cNombreGrupoProducto]) VALUES (3, N'1003', N'Electrodomesticos')
SET IDENTITY_INSERT [dbo].[GrupoProductos] OFF
SET IDENTITY_INSERT [dbo].[Productos] ON 
INSERT [dbo].[Productos] ([Id], [cSku], [cNombre], [cNombreExtrangero], [nPeso], [cUM], [nPrecioLista], [nPrecioBase], [cCodBarra], [cSkuFabricante], [cSkuAlternante], [GrupoProductoId], [FabricanteId]) VALUES (1, N'D100001', N'Portatil 15 A15', N'Laptop 15 A15"', CAST(1.55 AS Decimal(8, 2)), N'Kg', CAST(935.00 AS Decimal(8, 2)), CAST(850.00 AS Decimal(8, 2)), N'1020304050', N'D10A150001', N'D10A151001', 1, 1)
INSERT [dbo].[Productos] ([Id], [cSku], [cNombre], [cNombreExtrangero], [nPeso], [cUM], [nPrecioLista], [nPrecioBase], [cCodBarra], [cSkuFabricante], [cSkuAlternante], [GrupoProductoId], [FabricanteId]) VALUES (2, N'D100002', N'Portatil 15 L35', N'Laptop 15 L355"', CAST(1.46 AS Decimal(8, 2)), N'Kg', CAST(685.00 AS Decimal(8, 2)), CAST(550.00 AS Decimal(8, 2)), N'1030487050', N'D10L350001', N'D10L351001', 1, 1)
INSERT [dbo].[Productos] ([Id], [cSku], [cNombre], [cNombreExtrangero], [nPeso], [cUM], [nPrecioLista], [nPrecioBase], [cCodBarra], [cSkuFabricante], [cSkuAlternante], [GrupoProductoId], [FabricanteId]) VALUES (3, N'HP100001', N'Portatil 15 H15', N'Laptop 15 H15"', CAST(1.06 AS Decimal(8, 2)), N'Kg', CAST(935.00 AS Decimal(8, 2)), CAST(950.00 AS Decimal(8, 2)), N'1020304050', N'HP55H150001', N'HP56H151001', 1, 2)
INSERT [dbo].[Productos] ([Id], [cSku], [cNombre], [cNombreExtrangero], [nPeso], [cUM], [nPrecioLista], [nPrecioBase], [cCodBarra], [cSkuFabricante], [cSkuAlternante], [GrupoProductoId], [FabricanteId]) VALUES (4, N'HP1HD001', N'Disco 1TB', N'HD 1TB"', CAST(400.00 AS Decimal(8, 2)), N'gr', CAST(165.00 AS Decimal(8, 2)), CAST(150.00 AS Decimal(8, 2)), N'8320304050', N'HP1HD1TB001', N'HP1HD1TB1001', 2, 2)
INSERT [dbo].[Productos] ([Id], [cSku], [cNombre], [cNombreExtrangero], [nPeso], [cUM], [nPrecioLista], [nPrecioBase], [cCodBarra], [cSkuFabricante], [cSkuAlternante], [GrupoProductoId], [FabricanteId]) VALUES (5, N'HP1HD002', N'Disco 1.5TB', N'HD 1.5TB"', CAST(480.00 AS Decimal(8, 2)), N'gr', CAST(203.00 AS Decimal(8, 2)), CAST(185.00 AS Decimal(8, 2)), N'8320304650', N'HP1HD15TB01', N'HP1HD15TB101', 2, 2)
SET IDENTITY_INSERT [dbo].[Productos] OFF
SET IDENTITY_INSERT [dbo].[Proveedores] ON 
INSERT [dbo].[Proveedores] ([Id], [cNmbProveedor], [ProductoId]) VALUES (1, N'Infobest', 1)
INSERT [dbo].[Proveedores] ([Id], [cNmbProveedor], [ProductoId]) VALUES (2, N'Infobest', 2)
INSERT [dbo].[Proveedores] ([Id], [cNmbProveedor], [ProductoId]) VALUES (3, N'Dismac', 3)
INSERT [dbo].[Proveedores] ([Id], [cNmbProveedor], [ProductoId]) VALUES (4, N'M&M', 4)
INSERT [dbo].[Proveedores] ([Id], [cNmbProveedor], [ProductoId]) VALUES (5, N'Alienware', 5)
SET IDENTITY_INSERT [dbo].[Proveedores] OFF
SET IDENTITY_INSERT [dbo].[GrupoCliente] ON 
insert [dbo].[GrupoCliente] ([Id], [Nombre], [Codigo]) VALUES (1,'GRUPO PRUEBA', 1001)
SET IDENTITY_INSERT [dbo].[GrupoCliente] OFF
