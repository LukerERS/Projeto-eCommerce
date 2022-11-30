import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Categoria } from 'src/app/models/Categoria';
import { Produto } from 'src/app/models/Produto';
import {MatSnackBar} from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';

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
  erro!:String;


  constructor(
    private http: HttpClient,
    private router: Router,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.http.get<Categoria[]>("https://localhost:5001/api/categoria/listar")
    // Execução da requisição
    .subscribe({
      next: (categorias) => {
        this.categorias = categorias;
      }
    }),
    this.route.params.subscribe((params) => {
      let { id } = params;
      if(id !== undefined){
        this.http.get<Produto>
          (`https://localhost:5001/api/produto/buscar/${id}`)
          .subscribe({
            next: (produto) => {
              this.nome = produto.nome;
              this.preco = produto.preco;
              this.descricao = produto.descricao;
              this.produtoId = produto.id!;
              this.categoriaId = produto.categoriaId;
            },
          });
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
        this.router.navigate(["pages/produto/listar"]);
        console.log("Item adicionado com sucesso!");
      },
    });
    console.log(produto);
  }

  alterar(): void{
    let produto: Produto = {
      id : this.produtoId,
      nome : this.nome,
      descricao : this.descricao,
      preco : this.preco,
      categoriaId: this.categoriaId
    };
    //Requisição
    this.http.patch<Produto>("https://localhost:5001/api/produto/alterar", produto)
    .subscribe({
      next: (produto) => {
        this.router.navigate(["pages/produto/listar"]);
      },
      error: (error) => {
        if(error.status == 400){
          this.erro = "Erro de validação";
        }else if(error.status == 0){
          this.erro = "Inicie a sua API"
        }
      },
    });
  }

  openSnackBar(message: string, action: string){
    let snackBarRef = this.snackBar.open(message,action);
  }

}
