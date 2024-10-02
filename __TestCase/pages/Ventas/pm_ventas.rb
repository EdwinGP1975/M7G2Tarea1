
class PmVentas < Eirik::Page
    include RSpec::Matchers 
  
    URL = "#{$root_url}/Ventas"
    def initialize(page_manager)
      super(page_manager)
      add_element("btn_nuevo", "button", "class", "btn-add mdc-button mdc-button--unelevated mat-mdc-unelevated-button mat-primary mat-mdc-button-base", self, "always", false)
      add_element("btn_select_persona", "element", "formcontrolname", "personaId", self, "always", false)
      add_element("txt_nit", "text_field", "formcontrolname", "nitFacturacion", self, "always", false)
      add_element("txt_razon_social", "text_field", "formcontrolname", "nombreFacturacion", self, "always", false)
      add_element("txt_codigo", "text_field", "formcontrolname", "codigo", self, "always", false)
      add_element("btn_select_forma_pago", "element", "formcontrolname", "formaPago", self, "always", false)
      add_element("btn_select_producto", "element", "formcontrolname", "productoId", self, "always", false)
      add_element("txt_cantidad", "text_field", "formcontrolname", "cantidad", self, "always", false)
      add_element("btn_select_producto", "element", "formcontrolname", "productoId", self, "always", false)
      add_element("btn_select_um", "element", "formcontrolname", "unidadMedida", self, "always", false)
      add_element("btn_registrar", "button", "class", "mdc-button mdc-button--raised mat-mdc-raised-button mat-primary mat-mdc-button-base", self, "always", false)
      add_element("btn_agregar_detalle", "button", "class", "mdc-button mdc-button--raised mat-mdc-raised-button mat-primary mat-mdc-button-base", self, "always", false)

    end
  
    def registrarVenta(oVenta)
      btn_nuevo.click
      llenarCabecera(oVenta)
      btn_registrar.click
      llenarDatosProductos(oVenta)
    end
  
    def comprobarRegistro(oVenta)
      @browser.wait_until{@browser.table(:class => "mat-mdc-table mdc-data-table__table cdk-table mat-elevation-z8").td(:text => oVenta.nombre_factura).exists?}
      fila_producto = @browser.table(:class => "mat-mdc-table mdc-data-table__table cdk-table mat-elevation-z8").td(:text => oVenta.nombre_factura).parent
      expect(fila_producto.td(:index => 1).text).to eq(oVenta.codigo)
      expect(fila_producto.td(:index => 3).text).to eq(oVenta.nit)
      expect(fila_producto.td(:index => 4).text).to eq(oVenta.nombre_factura)
    end
  
    private
    def llenarCabecera(oVenta)
      btn_select_persona.click
      @browser.span(:text => oVenta.persona).click
      txt_nit.set oVenta.nit
      txt_razon_social.set oVenta.nombre_factura
      btn_select_forma_pago.click
      @browser.span(:text => oVenta.forma_pago).click
      txt_codigo.set oVenta.codigo
    end

    def llenarDatosProductos(oVenta)
        oVenta.productos.each do |producto|
            sleep 3
            btn_nuevo.click
            btn_select_producto.click
            @browser.span(:text => producto.nombre).click
            txt_cantidad.set producto.cantidad
            btn_select_um.click
            @browser.span(:text => producto.um).click
            btn_agregar_detalle.click
        end

    end
  
  end