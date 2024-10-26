import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

import { Persona } from '../personas/persona';

import { environment } from './../../environments/environment';


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
  fechaFormateada?: string;

  constructor(
    private http: HttpClient,
    private fb: FormBuilder,
    private activatedRoue: ActivatedRoute,
    private router: Router
  ) {
  }

  ngOnInit() {
    this.get();
    this.ObtenerFechaHoy();
    this.initForm();
    this.getPersonas();
  }

  ObtenerFechaHoy() {
    const fechaActual = new Date();
    const year = fechaActual.getFullYear();
    const month = String(fechaActual.getMonth() + 1).padStart(2, '0'); const day = String(fechaActual.getDate()).padStart(2, '0');

    this.fechaFormateada = year+'-'+month+'-'+day;
  }

  getPersonas() {
    var url = environment.baseUrl + 'api/Personas';
    this.http.get<Persona[]>(url).subscribe({
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
      fecha: [this.fechaFormateada, [Validators.required, Validators.maxLength(10)]],
      nitFacturacion: ['', [Validators.required, Validators.maxLength(12)]],
      nombreFacturacion: ['', [Validators.required, Validators.maxLength(20)]],
      conIva: [false],
      descuentoGlobal: [0],
      precioTotal: [0, [Validators.required, Validators.pattern('^-?[0-9]+(\\.[0-9]+)?$')]],
      precioTotalDescuento: [0, [Validators.required, Validators.pattern('^-?[0-9]+(\\.[0-9]+)?$')]],
      personaId: ['', [Validators.required, Validators.pattern('^[0-9]+$')]],
      formaPago: ['', [Validators.required]],
    });
  }

  openBlockNew() {
    this.showNew = true;
    this.initForm();
  }

  get() {
    var url = environment.baseUrl + 'api/Ventas';
    this.http.get<Ventas[]>(url).subscribe({
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
    var url = environment.baseUrl + 'api/Ventas';
    this.http.post<Ventas>(url, data).subscribe({
      next: (result) => {
        console.log(result);
        this.get();
        this.router.navigate(['/VentaDetalle/',result.id]);
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
