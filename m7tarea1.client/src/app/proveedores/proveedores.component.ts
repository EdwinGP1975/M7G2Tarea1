import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-proveedores',
  templateUrl: './proveedores.component.html',
  styleUrl: './proveedores.component.scss'
})
export class ProveedoresComponent {
  public proveedores: Proveedores[] = [];
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
    this.http.get<Proveedores[]>('/api/Proveedores').subscribe(
      (result) => {
        this.proveedores = result;
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
    this.http.post<any>('/api/Proveedores', data).subscribe(result => {
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
