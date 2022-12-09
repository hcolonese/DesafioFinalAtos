import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import {ActivatedRoute, Router, RouterModule} from '@angular/router';
import { VendasService } from 'src/app/services/vendas.service';
import { Venda } from 'src/app/models/venda.model';

@Component({
  selector: 'app-edit-venda',
  templateUrl: './edit-venda.component.html',
  styleUrls: ['./edit-venda.component.css'],  
  standalone: true,
  imports: [
    CommonModule, 
    RouterModule,
    FormsModule
  ],
})
export class EditVendaComponent {
  vendaDetails: Venda = {
    id: 0,
    dataVenda: new Date(''),
    operadora: '',
    cliente: '',
    apelido: '',
    tipo: '',
    valorContrato: 0,
    comissao: 0,
    parcela: 0
  }

  constructor(private route: ActivatedRoute, private vendasService: VendasService, private router: Router){}
  ngOnInit():void{
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');
        if(id){
          let num = parseInt(id)
          this.vendasService.getVenda(num).subscribe({
            next: (response) => {
              this.vendaDetails = response;
            }
          })
        }
      }
    })
}

  editVenda(){
    this.vendasService.editVenda(this.vendaDetails.id, this.vendaDetails).subscribe({
      next: (response) => {
        this.router.navigate(['vendas']);
      }
    });
  }

  deleteVenda(id: number){
    this.vendasService.deleteVenda(id).subscribe({
      next: (response) => {
        this.router.navigate(['vendas']);
      }
    });
  }
}
