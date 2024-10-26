import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { ActivatedRoute, Router } from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

import { Producto } from '../productos/producto';

import { environment } from './../../environments/environment';



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

  public showNew = false;
  public formFacturaVenta: FormGroup;
  public productos?: Producto[];

  constructor(
    private http: HttpClient,
    private activatedRoute: ActivatedRoute,
    private fb: FormBuilder,
    private router: Router) {
  }

  ngOnInit() {
    this.get();
    this.initForm();
    this.getProductos();
  }

  getProductos() {
    var url = environment.baseUrl + 'api/Productos';
    this.http.get<Producto[]>(url).subscribe({
      next: (result) => {
        this.productos = result;
      },
      error: (error) => {
        console.error(error);
      }
    });
  }

  initForm() {
    var idParam = this.activatedRoute.snapshot.paramMap.get('ventaId');
    var id = idParam ? +idParam : 0;

    this.formFacturaVenta = this.fb.group({
      cantidad: ['', [Validators.required, Validators.min(0), Validators.max(100), Validators.pattern('^[0-9]+$')]], // Validación de enteros entre 0 y 100
      unidadMedida: ['', [Validators.required]],
      precio: [0, [Validators.required, Validators.pattern('^-?[0-9]+(\\.[0-9]+)?$')]],
      descuentoItem: [0],
      precioDescuento: [0],
      ventaId: [id, Validators.required],
      productoId: ['', [Validators.required]]
    });
  }

  openBlockNew() {
    this.showNew = true;
    this.initForm();
  }

  get() {
    var idParam = this.activatedRoute.snapshot.paramMap.get('ventaId');
    var id = idParam ? +idParam : 0;

    var url = environment.baseUrl + 'api/ventaDetalle';
    this.http.get<VentaDetalle[]>(url).subscribe({
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

  registrar() {
    this.showNew = false;
    const data = this.formFacturaVenta.getRawValue()
    console.log('registrar', data);
    var url = environment.baseUrl + 'api/ventaDetalle';
    this.http.post<VentaDetalle>(url, data).subscribe({
      next: (result) => {
        console.log(result);
        this.get();
    }, error: (error) => console.log(error)
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
