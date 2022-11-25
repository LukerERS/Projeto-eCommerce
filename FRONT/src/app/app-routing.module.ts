import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


import { CadastrarCategoriaComponent } from './components/pages/cadastrar-categoria/cadastrar-categoria.component';
import { CadastrarClienteComponent } from './components/pages/cadastrar-cliente/cadastrar-cliente.component';
import { CadastrarProdutoComponent } from './components/pages/cadastrar-produto/cadastrar-produto.component';
import { ListarCategoriaComponent } from './components/pages/listar-categoria/listar-categoria.component';
import { ListarClienteComponent } from './components/pages/listar-clientes/listar-cliente.component';

const routes: Routes = [
  {
    path: "pages/produto/cadastrar",
    component: CadastrarProdutoComponent,
  },
  {
    path: "pages/cliente/cadastrar",
    component: CadastrarClienteComponent,
  },
  {
    path:"pages/categoria/cadastrar",
    component: CadastrarCategoriaComponent
  },
  {
    path: "pages/cliente/listar",
    component: ListarClienteComponent
  },
  {
    path: "pages/categoria/listar",
    component: ListarCategoriaComponent
  }

]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
