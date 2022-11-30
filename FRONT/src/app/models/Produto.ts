import { Categoria } from "./Categoria";
export interface Produto{
    id?:number;
    categoriaId:number;
    categoria?:Categoria;
    nome:String;
    descricao:String;
    preco:number;
}
