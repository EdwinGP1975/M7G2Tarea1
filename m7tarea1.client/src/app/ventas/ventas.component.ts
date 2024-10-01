import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

import { Persona } from '../personas/persona';

@Component({
  selector: 'app-ventas',
  templateUrl: './ventas.component.html',
  styleUrl: './ventas.component.scss'
})
export class VentasComponent {
  //table
  public displayedColumns: string[] = ['id', 'codigo', 'fecha', 'nitFacturacion', 'nombreFacturacion'
    , 'conIva','formaPago', 'descuentoGlobal', 'precioTotal', 'precioTotalDescuento','precioIva', 'precioTotalIva', 'personaId', 'empresaId'  ];
  public ventas!: MatTableDataSource<Ventas>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  public showNew = false;
  public formFacturaVenta: FormGroup;
  public personas?: Persona[];


  constructor(
    private http: HttpClient,
    private fb: FormBuilder,
  ) {
  }

  ngOnInit() {
    this.get();
    this.initForm();
    this.getPersonas();
  }

  getPersonas() {
    this.http.get<Persona[]>('/api/Personas').subscribe({
      next: (result) => {
        this.personas = result;
      },
      error: (error) => {
        console.error(error);
      }
    });
  }

  initForm() {
    this.formFacturaVenta = this.fb.group({
      codigo: ['', [Validators.required, Validators.maxLength(10)]],
      fecha: ['', [Validators.required, Validators.maxLength(10)]],
      nitFacturacion: ['', [Validators.required, Validators.maxLength(12)]],
      nombreFacturacion: ['', [Validators.required, Validators.maxLength(20)]],
      conIva: [false],
      descuentoGlobal: [0],
      precioTotal: ['', [Validators.required, Validators.pattern('^-?[0-9]+(\\.[0-9]+)?$')]],
      precioTotalDescuento: ['', [Validators.required, Validators.pattern('^-?[0-9]+(\\.[0-9]+)?$')]],
      personaId: ['', [Validators.required, Validators.pattern('^[0-9]+$')]],
      formaPago: ['', [Validators.required]],
    });
  }

  openBlockNew() {
    this.showNew = true;
    this.initForm();
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


  registrar() {
    this.showNew = false;
    const data = this.formFacturaVenta.getRawValue()
    console.log('registrar', data);
    this.http.post<Ventas>('/api/Ventas', data).subscribe({
      next: (result) => {
        console.log(result);
        this.get();
    }, error: (error) => console.log(error)
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
  precioIva: string;
  precioTotalIva: string;
  personaId: string;
  empresaId: string;
  formaPago: string;
}
