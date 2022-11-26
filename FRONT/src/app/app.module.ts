import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CadastrarClienteComponent } from './components/pages/cadastrar-cliente/cadastrar-cliente.component';
import { CadastrarProdutoComponent } from './components/pages/cadastrar-produto/cadastrar-produto.component';
import { CadastrarCategoriaComponent } from './components/pages/cadastrar-categoria/cadastrar-categoria.component';
import { ListarClienteComponent } from './components/pages/listar-clientes/listar-cliente.component';
import { ListarCategoriaComponent } from './components/pages/listar-categoria/listar-categoria.component';
import { CadastrarItemComponent } from './components/pages/cadastrar-item/cadastrar-item.component';



@NgModule({
  declarations: [
    AppComponent,
    CadastrarCategoriaComponent,
    CadastrarClienteComponent,
    CadastrarProdutoComponent,
    ListarClienteComponent,
    ListarCategoriaComponent,
    CadastrarItemComponent, 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
