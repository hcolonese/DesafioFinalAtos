import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Comissao } from 'src/app/models/comissao.model';
import { ComissoesService } from 'src/app/services/comissoes.service';

@Component({
  selector: 'app-comissoes-venda',
  templateUrl: './comissoes-venda.component.html',
  styleUrls: ['./comissoes-venda.component.css']
})
export class ComissoesVendaComponent implements OnInit{
  
  listaComissoes: Comissao[]= []
  constructor(private comissoesService: ComissoesService, private router: Router,private route: ActivatedRoute){}
  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');
        if(id){
          let num = parseInt(id)
          this.comissoesService.getAllComissoesVenda(num).subscribe({
            next: (comissoes) => {
              console.log(comissoes);
              this.listaComissoes = comissoes;
            },
            error: (response) => {
              console.log(response);
            }
          })
        }
      }
    })
  }
}

