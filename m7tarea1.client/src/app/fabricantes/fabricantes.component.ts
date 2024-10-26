import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

import { environment } from './../../environments/environment';

@Component({
  selector: 'app-fabricantes',
  templateUrl: './fabricantes.component.html',
  styleUrl: './fabricantes.component.scss',
})
export class FabricantesComponent {
  //table
  public displayedColumns: string[] = ['id', 'nombre'];
  public fabricantes!: MatTableDataSource<Fabricantes>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  //public fabricantes: Fabricantes[] = [];
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
    var url = environment.baseUrl + 'api/Fabricantes';
    this.http.get<Fabricantes[]>(url).subscribe({
      next: (result) => {
        this.fabricantes = new MatTableDataSource<Fabricantes>(result);
        this.fabricantes.paginator = this.paginator;
      },
      error: (error) => {
      console.error(error);
      }
    });
  }
  openBlockNew() {
    this.showNew = true;
  }
  registrar() {
    this.showNew = false;
    const data = this.formRegister.getRawValue()
    console.log('registrar', data);
    var url = environment.baseUrl + 'api/Fabricantes';
    this.http.post<any>(url, data).subscribe(result => {
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
