import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http'
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSnackBarModule} from '@angular/material/snack-bar';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CadastrarClienteComponent } from './components/pages/cadastrar-cliente/cadastrar-cliente.component';
import { CadastrarProdutoComponent } from './components/pages/cadastrar-produto/cadastrar-produto.component';
import { CadastrarCategoriaComponent } from './components/pages/cadastrar-categoria/cadastrar-categoria.component';
import { ListarClienteComponent } from './components/pages/listar-clientes/listar-cliente.component';
import { ListarCategoriaComponent } from './components/pages/listar-categoria/listar-categoria.component';
import { CadastrarItemComponent } from './components/pages/cadastrar-item/cadastrar-item.component';
import { CarrinhoComponent } from './components/pages/carrinho/carrinho.component';
import { ListarProdutoComponent } from './components/pages/listar-produto/listar-produto.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';



@NgModule({
  declarations: [
    AppComponent,
    CadastrarCategoriaComponent,
    CadastrarClienteComponent,
    CadastrarProdutoComponent,
    ListarClienteComponent,
    ListarCategoriaComponent,
    ListarProdutoComponent,
    CadastrarItemComponent,
    CarrinhoComponent, 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    //imports materiais Angular
    MatToolbarModule,
    MatIconModule,
    MatSidenavModule,
    MatListModule,
    MatButtonModule,
    MatCardModule,
    MatSelectModule,
    MatInputModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatSnackBarModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
