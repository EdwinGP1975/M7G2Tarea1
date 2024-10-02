Feature: Gestion de Ventas

  Background:

  Scenario: Registro de una nueva venta
    Given Usuario esta en la pagina de Gestion de Ventas 
    When Usuario registra una nueva venta con 1 solo producto
    Then Se comprueba el registro en base de datos de la nueva venta

  Scenario: Registro de una nueva venta
    Given Usuario esta en la pagina de Gestion de Ventas 
    When Usuario registra una nueva venta con 2 productos
    Then Se comprueba el registro en base de datos de la nueva venta    