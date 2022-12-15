import { Component, OnInit } from '@angular/core';
import { Comissao } from 'src/app/models/comissao.model';
import { Venda } from 'src/app/models/venda.model';
import { ComissoesService } from 'src/app/services/comissoes.service';

@Component({
  selector: 'app-comissoes-list',
  templateUrl: './comissoes-list.component.html',
  styleUrls: ['./comissoes-list.component.css']
})
export class ComissoesListComponent implements OnInit{

  listaComissoes: Comissao[]= []
  constructor(private comissoesService: ComissoesService){}
  ngOnInit(): void {
    this.comissoesService.getAllComissoes().subscribe({
      next: (comissoes) => {
        this.listaComissoes = comissoes;
      },
      error: (response) => {
        console.log(response);
      }
    });
  }
}
