import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

import { environment } from './../../environments/environment';


@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrl: './productos.component.scss'
})
export class ProductosComponent {
  //table
  public displayedColumns: string[] = ['id', 'sku', 'nombre', 'nombreExtrangero', 'peso', 'um', 'precioBase'
    , 'precioBase', 'codigoBarra','skuFabricante','skuAlternante','grupoProductoId','fabricanteId'  ];
  public productos!: MatTableDataSource<Productos>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

 // public productos: Productos[] = [];
  public showNew = false;
  public formRegister: FormGroup;

  constructor(private http: HttpClient,
    private fb: FormBuilder,
  ) { }

  ngOnInit() {
    this.get();
    this.initForm()
  }

  get() {
    var url = environment.baseUrl + 'api/Productos';
    this.http.get<Productos[]>(url).subscribe({
      next: (result) => {
        this.productos = new MatTableDataSource<Productos>(result);
        this.productos.paginator = this.paginator;
      },
      error: (error) => {
        console.error(error);
      }
    });
  }
  openBlockNew() {
    this.showNew = true;
  }
  registrar() {
    this.showNew = false;
    const data = this.formRegister.getRawValue()
    console.log('registrar', data);
    var url = environment.baseUrl + 'api/Productos';
    this.http.post<any>(url, data).subscribe(result => {
      console.log(result)
      this.get()
    });

  }
  initForm() {
    this.formRegister = this.fb.group({
      cSku: [null],
      cNombre: [null],
      cNombreExtrangero: [null],
      nPeso: [null],
      cUM: [null],
      nPrecioLista: [null],
      nPrecioBase: [null],
      cCodBarra: [null],
      cSkuFabricante: [null],
      cSkuAlternante: [null],
      grupoProductoId: [null],
      fabricanteId: [null],
      grupoProducto: [null],
      proveedores: [null],
      fabricante: [null],
    });
  }
}

interface Productos {
  id: number;
  cSku: string,
  cNombre: string,
  cNombreExtrangero: string,
  nPeso: number,
  cUM: string,
  nPrecioLista: number,
  nPrecioBase: number,
  cCodBarra: string,
  cSkuFabricante: string,
  cSkuAlternante: string,
  grupoProductoId: number,
  fabricanteId: number,
  grupoProducto: string,
  proveedores: string,
  fabricante: string
}

