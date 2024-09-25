import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';


@Component({
  selector: 'app-venta-detalle',
  templateUrl: './venta-detalle.component.html',
  styleUrl: './venta-detalle.component.scss'
})
export class VentaDetalleComponent {
  //table
  public displayedColumns: string[] = ['id', 'cantidad', 'unidadMedida', 'precio', 'descuentoItem'
    , 'precioDescuento', 'ventaId', 'productoId', 'servicioId'];
  public ventaDetalle!: MatTableDataSource<VentaDetalle>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private http: HttpClient) {
  }

  ngOnInit() {
    this.get();
    //this.initForm()
  }

  get() {
    this.http.get<VentaDetalle[]>('/api/ventaDetalle').subscribe({
      next: (result) => {
        this.ventaDetalle = new MatTableDataSource<VentaDetalle>(result);
        this.ventaDetalle.paginator = this.paginator;
      },
      error: (error) => {
        console.error(error);
      }
    });
  }
}

interface VentaDetalle {
  id: number;
  cantidad: string;
  unidadMedida: string;
  precio: string;
  descuentoItem: string;
  precioDescuento: string;
  descuentoventaIdGlobal: string;
  productoId: string;
  servicioId: string;
}
