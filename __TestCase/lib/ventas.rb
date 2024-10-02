class Venta
    attr_accessor :persona, :nit, :nombre_factura, :forma_pago, :codigo, :productos
  def initialize(persona, nit, nombre_factura, forma_pago, codigo)
    @persona = persona
    @nit = nit
    @nombre_factura = nombre_factura
    @forma_pago = forma_pago
    @codigo = codigo
  end

    def Venta.ventaUnProducto
        oVenta = Venta.new('Alfonos Quijarro Bonaventura', '123456', 'PRUEBA FACTURA', 'Efectivo', '00001')
        oVenta.productos = [
            ProductoVenta.new('Portatil 15 A15',5, "Unidad")
        ]
        oVenta
    end

    def Venta.ventaVariosProductos
        oVenta = Venta.new('Alfonos Quijarro Bonaventura', '123456', 'PRUEBA FACTURA', 'Efectivo', '00001')
        oVenta.productos = [
            ProductoVenta.new('Disco 1TB', 5, "Docena"),
            ProductoVenta.new('Disco 1.5TB',3, "Docena")
        ]
        oVenta
    end


end

class ProductoVenta
    attr_accessor :nombre, :cantidad, :um
  def initialize(nombre, cantidad, um)
    @nombre = nombre
    @cantidad = cantidad
    @um = um
  end
end
     