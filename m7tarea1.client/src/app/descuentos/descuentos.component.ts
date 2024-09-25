import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-descuentos',
  templateUrl: './descuentos.component.html',
  styleUrl: './descuentos.component.scss'
})
export class DescuentosComponent {
  //table
  public displayedColumns: string[] = ['id', 'porcentajeDescuento', 'fechaInicio', 'fechaFin','productoId', 'grupoClienteId'];
  public descuentos!: MatTableDataSource<Descuentos>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private http: HttpClient) {
  }

  ngOnInit() {
    this.get();
    //this.initForm()
  }

  get() {
    this.http.get<Descuentos[]>('/api/Descuentos').subscribe({
      next: (result) => {
        this.descuentos = new MatTableDataSource<Descuentos>(result);
        this.descuentos.paginator = this.paginator;
      },
      error: (error) => {
        console.error(error);
      }
    });
  }


}

interface Descuentos {
  id: number;
  porcentajeDescuento: string;
  fechaInicio: string;
  fechaFin: string;
  productoId: string;
  grupoClienteId: string
}
