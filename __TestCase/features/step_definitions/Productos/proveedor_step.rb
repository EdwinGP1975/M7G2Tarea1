
require 'proveedores.rb'

Given(/^Usuario esta en la pagina de Gestion de Proveedores$/) do
    page_manager.go_to(PmProveedores::URL)
end

When(/^Usuario registra un nuevo proveedor$/) do
    @oProveedores = Proveedor.nuevoProveedor
    page.registrarProveedor(@oProveedores)
end

Then(/^Se comprueba el registro en base de datos del proveedor$/) do
    page.comprobarRegistro(@oProveedores)
end