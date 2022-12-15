export interface Venda {
    id: number;
    dataVenda: Date;
    operadora: string;
    cliente: string;
    apelido: string;
    tipo: string;
    valorContrato: number;
    comissao: number;
    parcela: number;
}