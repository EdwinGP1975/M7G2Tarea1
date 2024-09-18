import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-grupo-productos',
  templateUrl: './grupo-productos.component.html',
  styleUrl: './grupo-productos.component.scss'
})
export class GrupoProductosComponent {
  public grupoProductos: GrupoProductos[] = [];
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
    this.http.get<GrupoProductos[]>('/api/GrupoProductos').subscribe(
      (result) => {
        this.grupoProductos = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }
  openBlockNew() {
    this.showNew = true;
  }
  registrar() {
    this.showNew = false;
    const data = this.formRegister.getRawValue()
    console.log('registrar', data);
    this.http.post<any>('/api/GrupoProductos', data).subscribe(result => {
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
