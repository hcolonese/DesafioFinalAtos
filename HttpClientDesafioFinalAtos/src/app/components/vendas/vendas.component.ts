import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../api.service';

@Component({
  selector: 'app-vendas',
  templateUrl: './vendas.component.html',
  styleUrls: ['./vendas.component.css']
})
export class VendasComponent implements OnInit{
  listaVendas: any;
  constructor(private apiService: ApiService) { }


  ngOnInit(): void {

  }
}
