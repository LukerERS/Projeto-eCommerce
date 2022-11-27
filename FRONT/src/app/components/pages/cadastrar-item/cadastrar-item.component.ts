import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { CarrinhoItem } from 'src/app/models/CarrinhoItem';
import { ActivatedRoute, Router } from "@angular/router";
import { Produto } from 'src/app/models/Produto';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-cadastrar-item',
  templateUrl: './cadastrar-item.component.html',
  styleUrls: ['./cadastrar-item.component.css']
})
export class CadastrarItemComponent implements OnInit {
    produtoId!: number; 
    quantidade!: number; 
    carrinhoId!: number; 
    produtos!: Produto[]; 

    constructor(
      private http: HttpClient,
      private router: Router,
      private route: ActivatedRoute,
      private snackBar: MatSnackBar
      ) { }

  ngOnInit(): void {
    this.http.get<Produto[]>
      ("https://localhost:5001/api/produto/listar")
      // Execução da requisição
      .subscribe({
        next: (produtos) => {
          this.produtos = produtos;
        }
      });
  }

  cadastrar(): void { 
    let carrinho: CarrinhoItem = {
      produtoId: this.produtoId, 
      quantidade: this.quantidade, 
      carrinhoId: 1,  
    };

    //REQUISIÇÂO HTTP
    this.http.post<CarrinhoItem>("https://localhost:5001/api/item/criar", carrinho)
    .subscribe({
      next: (carrinho) =>{
        //Quando a requisição for BEM SUCEDIDA
        console.log("Item adicionado com sucesso!");
      },
    });
    console.log(carrinho);
  }

  openSnackBar(message: string, action: string){
    let snackBarRef = this.snackBar.open(message,action);
  }

}
