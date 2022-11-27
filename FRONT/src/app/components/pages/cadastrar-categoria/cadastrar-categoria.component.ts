import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { ActivatedRoute, Router } from "@angular/router";
import { Categoria } from 'src/app/models/Categoria';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-cadastrar-categoria',
  templateUrl: './cadastrar-categoria.component.html',
  styleUrls: ['./cadastrar-categoria.component.css']
})
export class CadastrarCategoriaComponent implements OnInit {
  categoriaId!:number;
  tipo!:String;
  erro!: string;

  constructor(
    private http: HttpClient,
    private router: Router,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      let {id} = params;
      if(id !== undefined){
        this.http.get<Categoria>
        (`https://localhost:5001/api/categoria/buscar/${id}`)
        .subscribe({
          next: (categoria) => {
            this.tipo = categoria.tipo;
            this.categoriaId = categoria.id!;
          },
        });
      }
    });
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

  alterar():void{
    let categoria : Categoria ={
      id : this.categoriaId,
      tipo : this.tipo,
    };
    this.http.patch<Categoria>("https://localhost:5001/api/categoria/alterar", categoria)
    .subscribe({
      next: (categoria) => {
        this.router.navigate(["pages/categoria/listar"]);
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
