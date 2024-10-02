Feature: Gestion de Clientes

  Background:

  Scenario: Registro de un nuevo cliente
    Given Usuario esta en la pagina de Gestion de Clientes 
    When Usuario registra un nuevo cliente con todos los datos establecidos
    Then Se comprueba el registro en base de datos de la nueva persona