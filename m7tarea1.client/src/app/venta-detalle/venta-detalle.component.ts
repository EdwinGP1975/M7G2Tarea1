import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { ActivatedRoute, Router } from '@angular/router';
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

  constructor(
    private http: HttpClient,
    private activatedRoute: ActivatedRoute,
    private router: Router) {
  }

  ngOnInit() {
    this.get();
    //this.initForm()
  }

  get() {
    var idParam = this.activatedRoute.snapshot.paramMap.get('ventaId');
    var id = idParam ? +idParam : 0;

    this.http.get<VentaDetalle[]>('/api/ventaDetalle').subscribe({
      next: (result) => {
        let detalles: VentaDetalle[];
        if (id > 0) {
          detalles = result.filter(d => d.ventaId == id);
          this.ventaDetalle = new MatTableDataSource<VentaDetalle>(detalles);
          this.ventaDetalle.paginator = this.paginator;
        } else {
          this.ventaDetalle = new MatTableDataSource<VentaDetalle>(result);
          this.ventaDetalle.paginator = this.paginator;
        }        
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
  ventaId: number;
  productoId: string;
  servicioId: string;
}
