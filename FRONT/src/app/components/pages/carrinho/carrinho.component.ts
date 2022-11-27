import { Component, OnInit } from '@angular/core';
import { CarrinhoItem } from 'src/app/models/CarrinhoItem';
import { HttpClient } from "@angular/common/http";

@Component({
  selector: 'app-carrinho',
  templateUrl: './carrinho.component.html',
  styleUrls: ['./carrinho.component.css']
})
export class CarrinhoComponent implements OnInit {
  itens!: CarrinhoItem[]; 

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http
      .get<CarrinhoItem[]>("https://localhost:5001/api/item/carrinho/1")
      .subscribe({
        next: (itens) => {
          console.table(itens);
          this.itens = itens;
        },
      });
  }

  deletar(id: number): void{
    this.http.delete<CarrinhoItem>
      (`https://localhost:5001/api/item/deletar/${id}`)
      .subscribe({
        next: (funcionario) => {
          this.ngOnInit();
        },
      });
  }

}
