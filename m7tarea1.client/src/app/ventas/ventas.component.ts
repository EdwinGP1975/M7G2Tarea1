import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-ventas',
  templateUrl: './ventas.component.html',
  styleUrl: './ventas.component.scss'
})
export class VentasComponent {
  //table
  public displayedColumns: string[] = ['id', 'codigo', 'fecha', 'nitFacturacion', 'nombreFacturacion'
    , 'conIva', 'descuentoGlobal', 'precioTotal', 'precioTotalDescuento', 'personaId','empresaId'  ];
  public ventas!: MatTableDataSource<Ventas>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private http: HttpClient) {
  }

  ngOnInit() {
    this.get();
    //this.initForm()
  }

  get() {
    this.http.get<Ventas[]>('/api/Ventas').subscribe({
      next: (result) => {
        this.ventas = new MatTableDataSource<Ventas>(result);
        this.ventas.paginator = this.paginator;
      },
      error: (error) => {
        console.error(error);
      }
    });
  }
}

interface Ventas {
  id: number;
  codigo: string;
  fecha: string;
  nitFacturacion: string;
  nombreFacturacion: string;
  conIva: boolean;
  descuentoGlobal: string;
  precioTotal: string;
  precioTotalDescuento: string;
  personaId: string;
  empresaId: string;
}
