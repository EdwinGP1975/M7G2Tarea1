require 'watir'
require 'watir-scroll'
require 'eirik'
require 'rspec/expectations'
require './features/support/conexion'




# COMANDO PARA EJECUTAR ORDENADO
# cucumber .\features\login.feature .\features\cuenta_bancaria.feature -f junit -out ut
$root_url = "https://localhost:4200"
# $root_url = "http://localhost/DualbizErp"
# $root_url = "http://172.16.10.52/erpTesting"

$page_manager = Eirik::PageManager.new($root_url)
$page_manager.load_pages("#{Dir.pwd}/pages")

$client = Conexion.instance
$client.usar_bd_prueba unless ENV['FIX'] == 'N'