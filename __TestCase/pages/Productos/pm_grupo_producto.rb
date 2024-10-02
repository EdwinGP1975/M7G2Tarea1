
class PmGrupoProducto < Eirik::Page
    include RSpec::Matchers 
  
    URL = "#{$root_url}/GrupoProductos"
    
    def initialize(page_manager)
      super(page_manager)
      add_element("btn_nuevo", "button", "class", "mdc-button mdc-button--raised mat-mdc-raised-button mat-unthemed mat-mdc-button-base", self, "always", false)
      add_element("txt_grupo_producto", "text_field", "xpath", "//label[text()='Cod Grupo Producto : ']/following-sibling::input", self, "always", false)
      add_element("txt_nombre_grupo", "text_field", "xpath", "//label[text()='Nombre Grupo Producto : ']/following-sibling::input", self, "always", false)
      add_element("btn_registrar", "button", "class", "registrar", self, "always", false)
  
    end
  
    def registrarGrupoProducto(oGrupoProducto)
      btn_nuevo.click
      llenarDatos(oGrupoProducto)
      btn_registrar.click
    end
  
    def comprobarRegistro(oGrupoProducto)
      @browser.wait_until{@browser.table(:class => "mat-mdc-table mdc-data-table__table cdk-table mat-elevation-z8").td(:text => oGrupoProducto.nombre).exists?}
      fila_producto = @browser.table(:class => "mat-mdc-table mdc-data-table__table cdk-table mat-elevation-z8").td(:text => oGrupoProducto.nombre).parent
      expect(fila_producto.td(:index => 1).text).to eq(oGrupoProducto.codigo)
      expect(fila_producto.td(:index => 2).text).to eq(oGrupoProducto.nombre)
    end
  
    private
    def llenarDatos(oGrupoProducto)
      txt_grupo_producto.set oGrupoProducto.codigo
      txt_nombre_grupo.set oGrupoProducto.nombre
    end
  
  end