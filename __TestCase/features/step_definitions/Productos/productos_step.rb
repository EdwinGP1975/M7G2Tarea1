require 'producto.rb'

Given(/^Usuario esta en la pagina de Gestion de Productos$/) do
    page_manager.go_to(PmProductos::URL)
end



When(/^Usuario registra un nuevo producto$/) do
    @oProducto = Producto.nuevoProducto
    page.registrarProducto(@oProducto)
end

Then(/^Se comprueba el registro en base de datos del producto$/) do
    page.comprobarRegistro(@oProducto)
end
