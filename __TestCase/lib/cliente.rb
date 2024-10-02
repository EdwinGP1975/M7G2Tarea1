    class Cliente
        attr_accessor :codigo, :email, :grupo_cliente, :nombre, :apellido, :ci, :tipo_doc
      def initialize(codigo, email, grupo_cliente, nombre, apellido, ci, tipo_doc)
        @codigo = codigo
        @email = email
        @grupo_cliente = grupo_cliente
        @nombre = nombre
        @apellido = apellido
        @ci = ci
        @tipo_doc = tipo_doc
      end

        def Cliente.nuevoCliente
            oCliente = Cliente.new('011110', 'prueba@prueba.com', '1', 'Alfonos Quijarro', 'Bonaventura', '15324687', 'Cédula de identidad')
            oCliente
        end

    end
