export interface Venta {
  id: number;
  codigo: string;
  fecha: string;
  nitFacturacion: string;
  nombreFacturacion: string;
  conIva: boolean;
  formaPago: string;
  descuentoGlobal: string;
  precioTotal: string;
  precioTotalDescuento: string;
  personaId?: number;
  empresaId?: number|null;
}
