class PmCliente < Eirik::Page
  include RSpec::Matchers 

  URL = "#{$root_url}/Personas"
  def initialize(page_manager)
    super(page_manager)
    add_element("btn_nuevo", "button", "class", "btn-add mdc-button mdc-button--unelevated mat-mdc-unelevated-button mat-primary mat-mdc-button-base", self, "always", false)
    add_element("txt_codigo", "text_field", "id", "mat-input-0", self, "always", false)
    add_element("txt_ci", "text_field", "id", "mat-input-1", self, "always", false)
    add_element("txt_nombre", "text_field", "id", "mat-input-2", self, "always", false)
    add_element("txt_apellidos", "text_field", "id", "mat-input-3", self, "always", false)
    add_element("txt_email", "text_field", "id", "mat-input-4", self, "always", false)
    add_element("btn_select_tipo_doc", "element", "formcontrolname", "tipoDocumento", self, "always", false)

    add_element("btn_registrar", "button", "class", "mdc-button mdc-button--raised mat-mdc-raised-button mat-primary mat-mdc-button-base", self, "always", false)

  end

  def registrarCliente(oPersona)
    btn_nuevo.click
    llenarDatos(oPersona)
    btn_registrar.click
  end

  def comprobarRegistro(oPersona)
    @browser.wait_until{@browser.table(:class => "mat-mdc-table mdc-data-table__table cdk-table mat-elevation-z8").td(:text => oPersona.nombre).exists?}
    fila_producto = @browser.table(:class => "mat-mdc-table mdc-data-table__table cdk-table mat-elevation-z8").td(:text => oPersona.nombre).parent
    expect(fila_producto.td(:index => 1).text).to eq(oPersona.codigo)
    expect(fila_producto.td(:index => 2).text).to eq(oPersona.nombre)
    expect(fila_producto.td(:index => 3).text).to eq(oPersona.apellido)
    expect(fila_producto.td(:index => 4).text).to eq(oPersona.ci)
    expect(fila_producto.td(:index => 6).text).to eq(oPersona.email)
    expect(fila_producto.td(:index => 7).text).to eq(oPersona.grupo_cliente)
  end

  private
  def llenarDatos(oPersona)
    txt_codigo.set oPersona.codigo
    txt_email.set oPersona.email
    txt_nombre.set oPersona.nombre 
    txt_apellidos.set oPersona.apellido
    txt_ci.set oPersona.ci
    btn_select_tipo_doc.click
    @browser.span(:text => oPersona.tipo_doc).click
  end

end