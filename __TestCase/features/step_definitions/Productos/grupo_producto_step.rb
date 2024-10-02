
require 'grupo_producto.rb'

Given(/^Usuario esta en la pagina de Gestion de Grupo de productos$/) do
    page_manager.go_to(PmGrupoProducto::URL)
end

When(/^Usuario registra un nuevo grupo de productos en el sistema$/) do
    @oGrupoProducto = GrupoProducto.nuevoGrupoProducto
    page.registrarGrupoProducto(@oGrupoProducto)
end

Then(/^Se comprueba el registro en base de datos del grupo de productos$/) do
    page.comprobarRegistro(@oGrupoProducto)
end