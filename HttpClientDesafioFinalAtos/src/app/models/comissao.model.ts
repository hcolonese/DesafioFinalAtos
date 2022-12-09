import { Venda } from "./venda.model";

export interface Comissao {
    id: number;
    relatorio: string;
    notaFiscal: string;
    valor: number;
    dataRebimento: Date;
    vendaId: number;
    venda: Venda;
}