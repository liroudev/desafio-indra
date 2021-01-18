import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { Autor } from '../models/Autor';

@Component({
  selector: 'app-autores',
  templateUrl: './autores.component.html',
  styleUrls: ['./autores.component.css']
})
export class AutoresComponent implements OnInit {

  
  public titulo ="Lista dos Autores";
  public autorSelecionado: Autor|undefined|null;
  
  autores: any;

  
  constructor(private http: HttpClient) { }
  
  ngOnInit() {
    this.getAutores();
  }
  
  
  getAutores(){
    this.http.get('http://localhost:5000/api/autor').subscribe( response => {
    this.autores = response;
    console.log(response);
  }, error => {
    console.log(error);
  });
}

autorSelect(autor: any){
  this.autorSelecionado = autor;
}

voltar(){
  this.autorSelecionado = null;
}


}
