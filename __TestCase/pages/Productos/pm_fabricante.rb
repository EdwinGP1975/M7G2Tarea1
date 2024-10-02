
class PmFabricante < Eirik::Page
    include RSpec::Matchers 
  
    URL = "#{$root_url}/Fabricantes"
    
    def initialize(page_manager)
      super(page_manager)
      add_element("btn_nuevo", "button", "class", "mdc-button mdc-button--raised mat-mdc-raised-button mat-unthemed mat-mdc-button-base", self, "always", false)
      add_element("txt_nombre", "text_field", "xpath", "//label[text()='Nombre Fabricante : ']/following-sibling::input", self, "always", false)
      add_element("btn_registrar", "button", "class", "registrar", self, "always", false)
  
    end
  
    def registrarFabricante(oFabricante)
      btn_nuevo.click
      llenarDatos(oFabricante)
      btn_registrar.click
    end
  
    def comprobarRegistro(oFabricante)
      @browser.wait_until{@browser.table(:class => "mat-mdc-table mdc-data-table__table cdk-table mat-elevation-z8").td(:text => oFabricante.nombre).exists?}
      fila_producto = @browser.table(:class => "mat-mdc-table mdc-data-table__table cdk-table mat-elevation-z8").td(:text => oFabricante.nombre).parent
      expect(fila_producto.td(:index => 1).text).to eq(oFabricante.nombre)
    end
  
    private
    def llenarDatos(oFabricante)
        txt_nombre.set oFabricante.nombre
    end
  
  end