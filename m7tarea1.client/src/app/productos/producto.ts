export interface Producto {
  id: number;
  cSku: string,
  cNombre: string,
  cNombreExtrangero: string,
  nPeso: number,
  cUM: string,
  nPrecioLista: number,
  nPrecioBase: number,
  cCodBarra: string,
  cSkuFabricante: string,
  cSkuAlternante: string,
  grupoProductoId: number,
  fabricanteId: number,
  grupoProducto: string,
  proveedores: string,
  fabricante: string
}
