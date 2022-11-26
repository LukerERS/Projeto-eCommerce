import { Produto } from "./Produto"; 

export interface CarrinhoItem {
    id?: number; 
    produtoId: number; 
    produto?: Produto; 
    quantidade: number; 
    preco?: number; 
    total?:number; 
    carrinhoId?: number;
}