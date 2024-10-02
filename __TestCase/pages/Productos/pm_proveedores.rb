
class PmProveedores < Eirik::Page
    include RSpec::Matchers 
  
    URL = "#{$root_url}/Proveedores"
    
    def initialize(page_manager)
      super(page_manager)
      add_element("btn_nuevo", "button", "class", "mdc-button mdc-button--raised mat-mdc-raised-button mat-unthemed mat-mdc-button-base", self, "always", false)
      add_element("txt_nombre", "text_field", "xpath", "//label[text()='Nombre Proveedor : ']/following-sibling::input", self, "always", false)
      add_element("txt_producto", "text_field", "xpath", "//label[text()='Id Producto : ']/following-sibling::input", self, "always", false)
      add_element("btn_registrar", "button", "class", "registrar", self, "always", false)
  
    end
  
    def registrarProveedor(oProveedor)
      btn_nuevo.click
      llenarDatos(oProveedor)
      btn_registrar.click
    end
  
    def comprobarRegistro(oProveedor)
      @browser.wait_until{@browser.table(:class => "mat-mdc-table mdc-data-table__table cdk-table mat-elevation-z8").td(:text => oProveedor.nombre).exists?}
      fila_producto = @browser.table(:class => "mat-mdc-table mdc-data-table__table cdk-table mat-elevation-z8").td(:text => oProveedor.nombre).parent
      expect(fila_producto.td(:index => 1).text).to eq(oProveedor.nombre)
      expect(fila_producto.td(:index => 2).text).to eq(oProveedor.productoId)
    end
  
    private
    def llenarDatos(oProveedor)
      txt_nombre.set oProveedor.nombre
      txt_producto.set oProveedor.productoId
    end
  
  end