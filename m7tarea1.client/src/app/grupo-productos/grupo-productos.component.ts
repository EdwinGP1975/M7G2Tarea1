import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

import { environment } from './../../environments/environment';


@Component({
  selector: 'app-grupo-productos',
  templateUrl: './grupo-productos.component.html',
  styleUrl: './grupo-productos.component.scss'
})
export class GrupoProductosComponent {
  //table
  public displayedColumns: string[] = ['id', 'codigo', 'nombre'];
  public grupoProductos!: MatTableDataSource<GrupoProductos>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  //public grupoProductos: GrupoProductos[] = [];
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
    var url = environment.baseUrl + 'api/GrupoProductos';
    this.http.get<GrupoProductos[]>(url).subscribe({
      next: (result) => {
        this.grupoProductos = new MatTableDataSource<GrupoProductos>(result);
        this.grupoProductos.paginator = this.paginator;
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
    var url = environment.baseUrl + 'api/GrupoProductos';
    this.http.post<any>(url, data).subscribe(result => {
      console.log(result)
      this.get()
    });

  }
  initForm() {
    this.formRegister = this.fb.group({
      cCodGrupoProducto: [null],
      cNombreGrupoProducto: [null]

    });
  }
}

interface GrupoProductos {
  id: number;
  cCodGrupoProducto: string;
  cNombreGrupoProducto: string;
  productos: string;
}
