import { Categoria } from "./Categoria";
export interface Produto{
    id?:Number;
    categoriaId:Number;
    categoria?:Categoria;
    nome:String;
    descricao:String;
    preco:Number;
}
