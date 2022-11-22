import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Cliente } from 'src/app/models/Cliente';

@Component({
  selector: 'app-cadastrar-cliente',
  templateUrl: './cadastrar-cliente.component.html',
  styleUrls: ['./cadastrar-cliente.component.css']
})
export class CadastrarClienteComponent implements OnInit {

  nome!:String;
  email!:String;
  endereco!:String;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

}
