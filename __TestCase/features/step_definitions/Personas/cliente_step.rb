require 'cliente.rb'

Given(/^Usuario esta en la pagina de Gestion de Clientes$/) do
    page_manager.go_to(PmCliente::URL)
end



When(/^Usuario registra un nuevo cliente con todos los datos establecidos$/) do
    @oCliente = Cliente.nuevoCliente
    page.registrarCliente(@oCliente)
end

Then(/^Se comprueba el registro en base de datos de la nueva persona$/) do
    page.comprobarRegistro(@oCliente)
end
