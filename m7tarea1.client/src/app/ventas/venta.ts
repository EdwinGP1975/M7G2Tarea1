export interface Venta {
  id: number;
  codigo: string;
  fecha: string;
  nitFacturacion: string;
  nombreFacturacion: string;
  conIva: boolean;
  descuentoGlobal: string;
  precioTotal: string;
  precioTotalDescuento: string;
  personaId?: string;
  empresaId?: string;
}
