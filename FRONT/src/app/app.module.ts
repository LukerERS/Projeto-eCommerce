import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CadastrarClienteComponent } from './components/pages/cadastrar-cliente/cadastrar-cliente.component';
<<<<<<< HEAD
=======
import { CadastrarProdutoComponent } from './components/pages/cadastrar-produto/cadastrar-produto.component';
>>>>>>> e1319be ("envio")

@NgModule({
  declarations: [
    AppComponent,
<<<<<<< HEAD
    CadastrarClienteComponent
=======
    CadastrarClienteComponent,
    CadastrarProdutoComponent
>>>>>>> e1319be ("envio")
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
