import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AngularMaterialModule } from './angular-material.module';

import { HomeComponent } from './home/home.component';
import { FabricantesComponent } from './fabricantes/fabricantes.component';
import { GrupoProductosComponent } from './grupo-productos/grupo-productos.component';
import { ProductosComponent } from './productos/productos.component';
import { ProveedoresComponent } from './proveedores/proveedores.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { GrupoClienteComponent } from './grupo-cliente/grupo-cliente.component';
import { PersonasComponent } from './personas/personas.component';
import { DescuentosComponent } from './descuentos/descuentos.component';
import { VentasComponent } from './ventas/ventas.component';
import { VentaDetalleComponent } from './venta-detalle/venta-detalle.component';
import { VentaEditComponent } from './ventas/venta-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FabricantesComponent,
    GrupoProductosComponent,
    ProductosComponent,
    ProveedoresComponent,
    NavMenuComponent,
    GrupoClienteComponent,
    PersonasComponent,
    DescuentosComponent,
    VentasComponent,
    VentaDetalleComponent,
    VentaEditComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule,
    AngularMaterialModule    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
