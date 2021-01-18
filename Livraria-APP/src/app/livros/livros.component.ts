import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Livro } from '../models/Livro';

@Component({
  selector: 'app-livros',
  templateUrl: './livros.component.html',
  styleUrls: ['./livros.component.css']
})
export class LivrosComponent implements OnInit {
    

  public titulo ='Lista dos Livros';
  public livroSelecionado: Livro|undefined|null;

  livros: any;

  constructor(private http: HttpClient) { }
  
  ngOnInit() {
    this.getLivros();
  }
  
  getLivros(){
    this.http.get('http://localhost:5000/api/livro').subscribe( response => {
    this.livros = response;
    console.log(response);
  }, error => {
    console.log(error);
  });
}

livroSelect(livro: Livro){
  this.livroSelecionado = livro;
}

voltar(){
  this.livroSelecionado = null;
}

  
}
