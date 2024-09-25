import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
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
    this.http.get<Fabricantes[]>('/api/Fabricantes').subscribe({
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
