import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, AbstractControl, AsyncValidatorFn } from '@angular/forms';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from './../../environments/environment';
import { Venta } from './venta';

@Component({
  selector: 'app-venta-edit',
  templateUrl: './venta-edit.component.html',
  styleUrl: './venta-edit.component.scss'
})
export class VentaEditComponent implements OnInit {
  title?: string;
  form!: FormGroup;
  venta?: Venta;
  id?: number;

  constructor(
    private fb: FormBuilder,
    private activatedRoue: ActivatedRoute,
    private router: Router,
    private http: HttpClient) {
  }
  ngOnInit() {
    this.form = this.fb.group({
      codigo: [''],
      fecha: [''],
      nitFactura: [''],
      nombreFactura: [''],
      conIva: [''],
      formaPago:['unidad'],
      descuentoGlobal: [''],
      precioTotal: [''],
      precioTotalDescuento: [''],
      personaId: [''],
      empresaId: [null]
    });
    this.loadData();

  }

  loadData() {
    // ADD New mode
    this.title = "Crear una Venta";
  }

  onSubmit() {
    var venta: Venta = <Venta>{};
    venta.codigo = this.form.controls['codigo'].value;
    venta.fecha = this.form.controls['fecha'].value;
    venta.nitFacturacion = this.form.controls['nitFactura'].value;
    venta.nombreFacturacion = this.form.controls['nombreFactura'].value;
    venta.conIva = JSON.parse(this.form.controls['conIva'].value);
    venta.descuentoGlobal = this.form.controls['descuentoGlobal'].value;
    venta.precioTotal = this.form.controls['precioTotal'].value;
    venta.precioTotalDescuento = this.form.controls['precioTotalDescuento'].value;
    venta.personaId = this.form.controls['personaId'].value;
    venta.empresaId = this.form.controls['empresaId'].value;

    //Add New mode
    var url = environment.baseUrl + 'api/Ventas';
    this.http.post<Venta>(url, venta).subscribe({
      next: (result) => {
        console.log("Venta: ", result.id);

        this.router.navigate(['/Ventas']);
      },
      error: (error) => console.log(error)
    });
  }
}
