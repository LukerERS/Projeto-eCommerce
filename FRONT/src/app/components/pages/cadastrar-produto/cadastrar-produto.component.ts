import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Categoria } from 'src/app/models/Categoria';
import { Produto } from 'src/app/models/Produto';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-cadastrar-produto',
  templateUrl: './cadastrar-produto.component.html',
  styleUrls: ['./cadastrar-produto.component.css']
})
export class CadastrarProdutoComponent implements OnInit {
  categoriaId!: number;
  produtoId!:number
  nome!:String;
  descricao!:String;
  preco!:number;
  categorias!: Categoria[];


  constructor(
    private http: HttpClient,
    private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.http.get<Categoria[]>("https://localhost:5001/api/categoria/listar")
    // Execução da requisição
    .subscribe({
      next: (categorias) => {
        this.categorias = categorias;
      }
    });
  }
  cadastrar(): void { 
    let produto: Produto = {
      categoriaId: this.categoriaId, 
      nome: this.nome, 
      descricao: this.descricao,  
      preco: this.preco
    };

    //REQUISIÇÂO HTTP
    this.http.post<Produto>("https://localhost:5001/api/produto/cadastrar", produto)
    .subscribe({
      next: (produto) =>{
        //Quando a requisição for BEM SUCEDIDA
        console.log("Item adicionado com sucesso!");
      },
    });
    console.log(produto);
  }

  openSnackBar(message: string, action: string){
    let snackBarRef = this.snackBar.open(message,action);
  }

}
