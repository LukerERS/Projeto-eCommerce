import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Cliente } from 'src/app/models/Cliente';
import { ActivatedRoute, Router } from '@angular/router';
import { timeStamp } from 'console';
import { error } from '@angular/compiler/src/util';

@Component({
  selector: 'app-cadastrar-cliente',
  templateUrl: './cadastrar-cliente.component.html',
  styleUrls: ['./cadastrar-cliente.component.css']
})
export class CadastrarClienteComponent implements OnInit {

  nome!:String;
  email!:String;
  endereco!:String;
  erro!: string;
  clienteId!: number;

  constructor(
    private http: HttpClient,
    private router: Router,
    private route: ActivatedRoute
    ) { }

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      let { id } = params;
      if(id !== undefined){
        this.http.get<Cliente>
          (`https://localhost:5001/api/cliente/buscar/${id}`)
          .subscribe({
            next: (cliente) => {
              this.nome = cliente.nome;
              this.email = cliente.email;
              this.endereco = cliente.endereco;
              this.clienteId = cliente.id!;
            },
          });
      }
    });
  }

  cadastrar(): void {
    let cliente: Cliente = {
      nome : this.nome,
      email: this.email,
      endereco: this.endereco,
    };

    //REQUISIÇÂO HTTP
    this.http.post<Cliente>("https://localhost:5001/api/cliente/cadastrar", cliente)
    .subscribe({
      next: (cliente) =>{
        //Quando a requisição for BEM SUCEDIDA
        console.log("Cadastrado com sucesso!");
      },
    });
    console.log(cliente);
  }

  alterar(): void{
    let cliente: Cliente = {
      id : this.clienteId,
      nome : this.nome,
      email : this.email,
      endereco : this.endereco,
    };
    //Requisição
    this.http.patch<Cliente>("https://localhost:5001/api/cliente/alterar", cliente)
    .subscribe({
      next: (cliente) => {
        this.router.navigate(["pages/cliente/listar"]);
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

}

