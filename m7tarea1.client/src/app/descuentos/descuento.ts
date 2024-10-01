export interface Descuento {
  id: number;
  porcentajeDescuento: number;
  fechaInicio: string;
  fechaFin: string;
  productoId: number;
  grupoClienteId: number;
}
