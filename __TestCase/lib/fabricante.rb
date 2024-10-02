class Fabricante
    attr_accessor :nombre
    def initialize(nombre)
        @nombre = nombre
    end
    
    def Fabricante.nuevoFabricante
        pFabricante = Fabricante.new('ASUS')
        pFabricante
    end



end