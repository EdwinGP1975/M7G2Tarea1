class Proveedor
    attr_accessor :nombre, :productoId
    def initialize(nombre, productoId)
        @nombre = nombre
        @productoId = productoId
    end
    
    def Proveedor.nuevoProveedor
        oProveedor = Proveedor.new('ACER', '6')
        oProveedor
    end



end