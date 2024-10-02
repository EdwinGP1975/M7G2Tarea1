
require 'fabricante.rb'

Given(/^Usuario esta en la pagina de Gestion de Fabricantes$/) do
    page_manager.go_to(PmFabricante::URL)
end

When(/^Usuario registra un nuevo fabricante$/) do
    @oFabricante = Fabricante.nuevoFabricante
    page.registrarFabricante(@oFabricante)
end

Then(/^Se comprueba el registro en base de datos del fabricante$/) do
    page.comprobarRegistro(@oFabricante)
end