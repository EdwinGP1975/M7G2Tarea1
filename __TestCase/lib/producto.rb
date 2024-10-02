    class Producto
        attr_accessor :sku, :nombre, :nombre_extranjero, :peso, :um, :precio_lista, :precio_base, :cod_barra, :sku_fabricante, :sku_alternate, :grupo_producto, :fabricante
      def initialize(sku, nombre, nombre_extranjero, peso, um, precio_lista, precio_base, cod_barra, sku_fabricante, sku_alternate, grupo_producto, fabricante)
        @sku = sku
        @nombre = nombre
        @nombre_extranjero = nombre_extranjero
        @peso = peso
        @um = um
        @precio_lista = precio_lista
        @precio_base = precio_base
        @cod_barra = cod_barra
        @sku_fabricante = sku_fabricante
        @sku_alternate = sku_alternate
        @grupo_producto = grupo_producto
        @fabricante = fabricante
      end

        def Producto.nuevoProducto
            pProducto = Producto.new('D100003', 'PIEZAS PRUEBAS', 'PIEZAS PRUEBAS EXTRANJERO', '100', 'Kg', '350', '300', '1020304058', 'D10A150011', 'D10A151011', '4', '5')
            pProducto
        end

    end
