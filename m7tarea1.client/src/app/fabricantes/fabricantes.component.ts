import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-fabricantes',
  templateUrl: './fabricantes.component.html',
  styleUrl: './fabricantes.component.scss',
})
export class FabricantesComponent {
  public fabricantes: Fabricantes[] = [];
  public showNew = false;
  public formRegister: FormGroup = this.fb.group({
    cNmbFabricante: [null]
  });;

  constructor(
    private http: HttpClient,
    private fb: FormBuilder,
  ) { }

  ngOnInit() {
    this.get();
    //this.initForm()
  }

  get() {
    this.http.get<Fabricantes[]>('/api/Fabricantes').subscribe(
      (result) => {
        this.fabricantes = result;
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
    this.http.post<any>('/api/Fabricantes', data).subscribe(result => {
      console.log(result)
      this.get()
    });

  }
  initForm() {
    this.formRegister = this.fb.group({
      cNmbFabricante: [null]
    });
  }
}

interface Fabricantes {
  id: number;
  cNmbFabricante: string;
  productos: string;
}
