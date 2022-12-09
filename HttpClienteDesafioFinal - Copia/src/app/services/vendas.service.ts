import { formatDate } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Venda } from '../models/venda.model';

@Injectable({
  providedIn: 'root'
})
export class VendasService {
  private readonly API = 'https://localhost:7097/'
  constructor(private http: HttpClient) { }

  getAllVendas():Observable<Venda[]>{
    return this.http.get<Venda[]>(this.API + 'Api/vendas');
  }
  addVenda(addVendaRequest: Venda):Observable<Venda>{
    let dateString = addVendaRequest.dataVenda;
    let newDate = new Date(dateString)
    addVendaRequest.dataVenda = newDate;
    return this.http.post<Venda>(this.API + 'Api/vendas', addVendaRequest);
  }
  getVenda(id: number):Observable<Venda>{
    return this.http.get<Venda>(this.API + "Api/vendas/" + id); 
  }
  editVenda(id:number, editVendaRequest:Venda):Observable<Venda>{
    return this.http.put<Venda>(this.API + 'Api/vendas/'+ id,editVendaRequest);
  }
  deleteVenda(id: number):Observable<Venda>{
    return this.http.delete<Venda>(this.API + "Api/vendas/" + id); 
  }
}
