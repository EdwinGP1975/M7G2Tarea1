require 'tiny_tds'
require 'singleton'

class Conexion
    include Singleton
    def initialize
        @conexion = TinyTds::Client.new username: 'sa', password: 'Flavia123', dataserver: 'localhost\\SQLEXPRESS', timeout: 121
        self
    end

    @conexion = nil

    def selectAll(tabla)
        sql = "SELECT * FROM [#{tabla}]"
        result = @conexion.execute(sql)
        result.each(:symbolize_keys => true)
        # puts("Conexión: #{@conexion}\tSQL: #{sql}")
    end

    def selectWhere(tabla, fila, operador, valor, tipo_valor, una_fila)
        # tipo_valor = :int, :char
        if tipo_valor == :char
            valor = "'#{valor}'"
        end
        sql = "SELECT * FROM [#{tabla}] WHERE #{fila} #{operador} #{valor}"
        result = @conexion.execute(sql)
        result.each(:symbolize_keys => true)
        if una_fila == :una_fila
            result.first
        else
            result
        end        
    end

    def cargarFixtures(bd='prueba')
        case bd
        when 'prueba'
            cargarFixturesprueba
        end
    end
    def usar_bd_prueba
        puts "Conectando a bd_prueba"
        @conexion.execute("USE bd_prueba").do
    end

    def cargarFixturesprueba
        puts "Conectando a bd_prueba"
        @conexion.execute("USE bd_prueba").do
        puts "clean_tables.sql"
        @conexion.execute(IO.read("fixture-files\\clean_tables.sql")).do
        puts "insert_tables.sql"
        @conexion.execute(IO.read("fixture-files\\insert_tables.sql")).do
    end

    def ejecutar(instruccion_sql)
        @conexion.execute(instruccion_sql).do
    end

    def cerrarConexion
        @conexion.close
    end
end