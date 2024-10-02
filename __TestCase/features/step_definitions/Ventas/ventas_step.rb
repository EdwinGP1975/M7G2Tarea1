require 'ventas.rb'

Given(/^Usuario esta en la pagina de Gestion de Ventas$/) do
    page_manager.go_to(PmVentas::URL)
end



When(/^Usuario registra una nueva venta con 1 solo producto$/) do
    @oVenta = Venta.ventaUnProducto
    page.registrarVenta(@oVenta)
end

When(/^Usuario registra una nueva venta con mas de 1 producto$/) do
    @oVenta = Venta.ventaVariosProductos
    page.registrarVenta(@oVenta)
end


Then(/^Se comprueba el registro en base de datos de la nueva venta$/) do
    page_manager.go_to(PmVentas::URL)
    page.comprobarRegistro(@oVenta)
end
