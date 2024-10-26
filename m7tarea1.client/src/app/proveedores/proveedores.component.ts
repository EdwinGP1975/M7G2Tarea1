import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

import { environment } from './../../environments/environment';


@Component({
  selector: 'app-proveedores',
  templateUrl: './proveedores.component.html',
  styleUrl: './proveedores.component.scss'
})
export class ProveedoresComponent {
  //table
  public displayedColumns: string[] = ['id', 'nombre', 'productoId'];
  public proveedores!: MatTableDataSource<Proveedores>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  //public proveedores: Proveedores[] = [];
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
    var url = environment.baseUrl + 'api/Proveedores';
    this.http.get<Proveedores[]>(url).subscribe({
      next: (result) => {
        this.proveedores = new MatTableDataSource<Proveedores>(result);
        this.proveedores.paginator = this.paginator;
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
    var url = environment.baseUrl + 'api/Proveedores';
    this.http.post<any>(url, data).subscribe(result => {
      console.log(result)
      this.get()
    });

  }
  initForm() {
    this.formRegister = this.fb.group({
      cNmbProveedor: [null],
      productoId: [null]
    });
  }
}

interface Proveedores {
  id: number;
  cNmbProveedor: string;
  productoId: number;
  producto: string;
}
