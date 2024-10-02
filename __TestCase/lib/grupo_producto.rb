class GrupoProducto
    attr_accessor :codigo, :nombre
    def initialize(codigo, nombre)
        @codigo = codigo
        @nombre = nombre
    end
    
    def GrupoProducto.nuevoGrupoProducto
        oGrupoProducto = GrupoProducto.new('1004', 'Externos')
        oGrupoProducto
    end



end