import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Comissao } from '../models/comissao.model';
import { Venda } from '../models/venda.model';

@Injectable({
  providedIn: 'root'
})
export class ComissoesService {
  private readonly API = 'https://localhost:7065/'
  constructor(private http: HttpClient) { }

  getAllComissoes():Observable<Comissao[]>{
    return this.http.get<Comissao[]>(this.API + 'Api/comissoes');
  }
  getAllComissoesVenda(id: number):Observable<Comissao[]>{
    return this.http.get<Comissao[]>(this.API + 'Api/comissoesVenda/' + id);
  }
  addComissao(addComissaoRequest: Comissao):Observable<Comissao>{
    let venda = this.http.get<Venda>(this.API + "Api/vendas/" + addComissaoRequest.vendaId); 
    venda.subscribe({
      next: (params) => {
        addComissaoRequest.venda.id = params.id
        addComissaoRequest.venda.dataVenda = params.dataVenda
        addComissaoRequest.venda.operadora = params.operadora
        addComissaoRequest.venda.cliente = params.cliente
        addComissaoRequest.venda.apelido = params.apelido
        addComissaoRequest.venda.tipo = params.tipo
        addComissaoRequest.venda.valorContrato = params.valorContrato
        addComissaoRequest.venda.comissao = params.comissao
        addComissaoRequest.venda.parcela = params.parcela
      }
    })
    let dateString = addComissaoRequest.dataRebimento;
    let newDate = new Date(dateString)
    addComissaoRequest.dataRebimento = newDate;
    return this.http.post<Comissao>(this.API + 'Api/comissoes', addComissaoRequest);
  }
  getComissao(id: number):Observable<Comissao>{
    return this.http.get<Comissao>(this.API + "Api/comissoes/" + id); 
  }
  editComissao(id:number, editComissaoRequest:Comissao):Observable<Comissao>{
    return this.http.put<Comissao>(this.API + 'Api/comissoes/'+ id,editComissaoRequest);
  }
  deleteComissao(id: number):Observable<Comissao>{
    return this.http.delete<Comissao>(this.API + "Api/comissoes/" + id); 
  }
}
