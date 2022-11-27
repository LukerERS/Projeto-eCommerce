import { Categoria } from "./Categoria";
export interface Produto{
    id?:Number;
    categoriaID:Number;
    categoria?:Categoria;
    nome:String;
    descricao:String;
    preco:Number;
}
