import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-personas',
  templateUrl: './personas.component.html',
  styleUrl: './personas.component.scss'
})
export class PersonasComponent {
  //table
  public displayedColumns: string[] = ['id', 'codigo', 'nombre', 'apellidos', 'email', 'grupoClienteId'];
  public personas!: MatTableDataSource<Personas>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private http: HttpClient) {
  }

  ngOnInit() {
    this.get();
    //this.initForm()
  }

  get() {
    this.http.get<Personas[]>('/api/Personas').subscribe({
      next: (result) => {
        this.personas = new MatTableDataSource<Personas>(result);
        this.personas.paginator = this.paginator;
      },
      error: (error) => {
        console.error(error);
      }
    });
  }


}

interface Personas {
  id: number;
  nombre: string;
  apellidos: string;
  codigo: string;
  email: string;
  grupoClienteId: string;
}
