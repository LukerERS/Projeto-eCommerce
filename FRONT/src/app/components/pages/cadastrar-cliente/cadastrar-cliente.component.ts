import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Cliente } from 'src/app/models/Cliente';
import { ActivatedRoute, Router } from '@angular/router';

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

  constructor(
    private http: HttpClient,
    private router: Router,
    private route: ActivatedRoute
    ) { }

  ngOnInit(): void {
    this.route.params.subscribe((params) =>{
      let { id } = params;
      if ( id !== undefined){
        console.log(id);
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

}

