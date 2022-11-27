import { Component, OnInit } from '@angular/core';
import { Produto } from 'src/app/models/Produto';
import { HttpClient } from "@angular/common/http";
import { Categoria } from 'src/app/models/Categoria';

@Component({
  selector: 'app-listar-produto',
  templateUrl: './listar-produto.component.html',
  styleUrls: ['./listar-produto.component.css']
})
export class ListarProdutoComponent implements OnInit {
  produtos!: Produto[];
  
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<Produto[]>("https://localhost:5001/api/produto/listar")
    .subscribe({
      next: (produtos) => {
        console.table(produtos)
        this.produtos = produtos;
      }
    });
  }
  deletar(id:Number):void{
    this.http.delete<Categoria>(`https://localhost:5001/api/produto/deletar/${id}`)
    .subscribe({
      next:(produto) =>{
        this.ngOnInit();
      },
    });
  }

}
