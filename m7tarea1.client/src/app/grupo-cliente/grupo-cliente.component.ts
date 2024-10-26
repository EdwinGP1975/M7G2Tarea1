import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

import { environment } from './../../environments/environment';


@Component({
  selector: 'app-grupo-cliente',
  templateUrl: './grupo-cliente.component.html',
  styleUrl: './grupo-cliente.component.scss'
})
export class GrupoClienteComponent {

  //table
  public displayedColumns: string[] = ['id', 'codigo', 'nombre'];
  public grupoClientes!: MatTableDataSource<GrupoClientes>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private http: HttpClient) {
  }

  ngOnInit() {
    this.get();
    //this.initForm()
  }

  get() {
    var url = environment.baseUrl + 'api/GrupoClientes';
    this.http.get<GrupoClientes[]>(url).subscribe({
      next: (result) => {
        this.grupoClientes = new MatTableDataSource<GrupoClientes>(result);
        this.grupoClientes.paginator = this.paginator;
      },
      error: (error) => {
        console.error(error);
      }
    });
  }


}

interface GrupoClientes {
  id: number;
  nombre: string;
  codigo: string;
}
