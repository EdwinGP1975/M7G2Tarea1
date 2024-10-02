Feature: Gestion de Productos

  Background:

  Scenario: Registro de un nuevo fabricante
    Given Usuario esta en la pagina de Gestion de Fabricantes 
    When Usuario registra un nuevo fabricante
    Then Se comprueba el registro en base de datos del fabricante 

  Scenario: Registro de un nuevo grupo de productos en el sistema
    Given Usuario esta en la pagina de Gestion de Grupo de productos 
    When Usuario registra un nuevo grupo de productos en el sistema
    Then Se comprueba el registro en base de datos del grupo de productos 
    

  Scenario: Registro de un nuevo producto en el sistema
    Given Usuario esta en la pagina de Gestion de Productos
    When Usuario registra un nuevo producto
    Then Se comprueba el registro en base de datos del producto 

  Scenario: Registro de un nuevo proveedor en el sistema
    Given Usuario esta en la pagina de Gestion de Proveedores
    When Usuario registra un nuevo proveedor
    Then Se comprueba el registro en base de datos del proveedor         

