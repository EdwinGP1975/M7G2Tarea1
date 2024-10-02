
class PmProductos < Eirik::Page
  include RSpec::Matchers 

  URL = "#{$root_url}/Productos"
  def initialize(page_manager, pElementsSelectors = nil)
    super(page_manager)
    add_element("btn_nuevo", "button", "class", "mdc-button mdc-button--raised mat-mdc-raised-button mat-unthemed mat-mdc-button-base", self, "always", false)
    add_element("txt_sku", "text_field", "xpath", "//label[text()='Sku : ']/following-sibling::input", self, "always", false)
    add_element("txt_nombre", "text_field", "xpath", "//label[text()='Nombre : ']/following-sibling::input", self, "always", false)
    add_element("txt_nomb_extranjero", "text_field", "xpath", "//label[text()='Nombre Extrangero : ']/following-sibling::input", self, "always", false)
    add_element("txt_peso", "text_field", "xpath", "//label[text()='Peso : ']/following-sibling::input", self, "always", false)
    add_element("txt_um", "text_field", "xpath", "//label[text()='UM : ']/following-sibling::input", self, "always", false)
    add_element("txt_precio_lista", "text_field", "xpath", "//label[text()='Precio Lista : ']/following-sibling::input", self, "always", false)
    add_element("txt_precio_base", "text_field", "xpath", "//label[text()='Precio Base : ']/following-sibling::input", self, "always", false)
    add_element("txt_cod_barra", "text_field", "xpath", "//label[text()='Cod Barra : ']/following-sibling::input", self, "always", false)
    add_element("txt_sku_fabricante", "text_field", "xpath", "//label[text()='Sku Fabricante : ']/following-sibling::input", self, "always", false)
    add_element("txt_sku_alternate", "text_field", "xpath", "//label[text()='Sku Alternante : ']/following-sibling::input", self, "always", false)
    add_element("txt_grupo_producto", "text_field", "xpath", "//label[text()='grupo Producto Id : ']/following-sibling::input", self, "always", false)
    add_element("txt_fabricante", "text_field", "xpath", "//label[text()='fabricante Id : ']/following-sibling::input", self, "always", false)
    add_element("btn_registrar", "button", "class", "registrar", self, "always", false)

  end

  def registrarProducto(oProducto)
    btn_nuevo.click
    llenarDatos(oProducto)
    btn_registrar.click
  end

  def comprobarRegistro(oProducto)
    @browser.wait_until{@browser.table(:class => "mat-mdc-table mdc-data-table__table cdk-table mat-elevation-z8").td(:text => oProducto.nombre).exists?}
    fila_producto = @browser.table(:class => "mat-mdc-table mdc-data-table__table cdk-table mat-elevation-z8").td(:text => oProducto.nombre).parent
    expect(fila_producto.td(:index => 1).text).to eq(oProducto.sku)
    expect(fila_producto.td(:index => 2).text).to eq(oProducto.nombre)
    expect(fila_producto.td(:index => 3).text).to eq(oProducto.nombre_extranjero)
    expect(fila_producto.td(:index => 4).text).to eq(oProducto.peso)
    expect(fila_producto.td(:index => 5).text).to eq(oProducto.um)
    expect(fila_producto.td(:index => 6).text).to eq(oProducto.precio_base)
    expect(fila_producto.td(:index => 7).text).to eq(oProducto.precio_base)
    expect(fila_producto.td(:index => 8).text).to eq(oProducto.cod_barra)
    expect(fila_producto.td(:index => 9).text).to eq(oProducto.sku_fabricante)
    expect(fila_producto.td(:index => 10).text).to eq(oProducto.sku_alternate)
    expect(fila_producto.td(:index => 11).text).to eq(oProducto.grupo_producto)
    expect(fila_producto.td(:index => 12).text).to eq(oProducto.fabricante)

  end

  private
  def llenarDatos(oProducto)
    txt_sku.set oProducto.sku
    txt_nombre.set oProducto.nombre
    txt_nomb_extranjero.set oProducto.nombre_extranjero
    txt_peso.set oProducto.peso 
    txt_um.set oProducto.um
    txt_precio_lista.set oProducto.precio_lista
    txt_precio_base.set oProducto.precio_base 
    txt_cod_barra.set oProducto.cod_barra  
    txt_sku_fabricante.set oProducto.sku_fabricante
    txt_sku_alternate.set oProducto.sku_alternate
    txt_grupo_producto.set oProducto.grupo_producto
    txt_fabricante.set oProducto.fabricante
  end

end