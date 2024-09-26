import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { FabricantesComponent } from './fabricantes/fabricantes.component';
import { GrupoProductosComponent } from './grupo-productos/grupo-productos.component';
import { ProveedoresComponent } from './proveedores/proveedores.component';
import { ProductosComponent } from './productos/productos.component';
import { GrupoClienteComponent } from './grupo-cliente/grupo-cliente.component';
import { DescuentosComponent } from './descuentos/descuentos.component';
import { PersonasComponent } from './personas/personas.component';
import { VentasComponent } from './ventas/ventas.component';
import { VentaDetalleComponent } from './venta-detalle/venta-detalle.component';
import { VentaEditComponent } from './ventas/venta-edit.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'Fabricantes', component: FabricantesComponent },
  { path: 'GrupoProductos', component: GrupoProductosComponent },
  { path: 'Proveedores', component: ProveedoresComponent },
  { path: 'Productos', component: ProductosComponent },
  { path: 'GrupoClientes', component: GrupoClienteComponent },
  { path: 'Descuentos', component: DescuentosComponent },
  { path: 'Personas', component: PersonasComponent },
  { path: 'Ventas', component: VentasComponent },
  { path: 'VentaDetalle', component: VentaDetalleComponent },
  { path: 'VentaDetalle/:ventaId', component: VentaDetalleComponent },
  { path: 'VentaEdit', component: VentaEditComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
