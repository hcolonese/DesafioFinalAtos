import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Comissao } from 'src/app/models/comissao.model';
import { Venda } from 'src/app/models/venda.model';
import { ComissoesService } from 'src/app/services/comissoes.service';

@Component({
  selector: 'app-edit-comissao',
  templateUrl: './edit-comissao.component.html',
  styleUrls: ['./edit-comissao.component.css']
})
export class EditComissaoComponent implements OnInit{
  vendaNull: Venda = {
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
  comissaoDetails: Comissao = {
    id: 0,
    relatorio: '',
    notaFiscal: '',
    valor: 0,
    dataRebimento: new Date(''),
    fkVenda: 0,
    venda: this.vendaNull
  }
  constructor(private route: ActivatedRoute, private comissaoService: ComissoesService, private router: Router){}

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');
        if(id){
          let num = parseInt(id)
          this.comissaoService.getComissao(num).subscribe({
            next: (response) => {
              this.comissaoDetails = response;
            }
          })
        }
      }
    })
  }

  editComissao(){
    this.comissaoService.editComissao(this.comissaoDetails.id, this.comissaoDetails).subscribe({
      next: (response) => {
        this.router.navigate(['comissoes']);
      }
    });
  }

  deleteComissao(id: number){
    this.comissaoService.deleteComissao(id).subscribe({
      next: (response) => {
        this.router.navigate(['comissoes']);
      }
    });
  }
}
