import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { ActivatedRoute, Router } from "@angular/router";
import { Categoria } from 'src/app/models/Categoria';

@Component({
  selector: 'app-cadastrar-categoria',
  templateUrl: './cadastrar-categoria.component.html',
  styleUrls: ['./cadastrar-categoria.component.css']
})
export class CadastrarCategoriaComponent implements OnInit {
  categoriaId!:Number;
  tipo!:String;

  constructor(
    private http: HttpClient,
    private router: Router,
    private route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    
  }
  cadastrar():void{
    let categoria: Categoria = {
      tipo: this.tipo,
    }
  this.http.post<Categoria>("https://localhost:5001/api/categoria/cadastrar", categoria)
    .subscribe({
      next:(categoria) => {
        console.log("Cadastramos!");
      },
    });
    console.log(categoria);
  }

}
