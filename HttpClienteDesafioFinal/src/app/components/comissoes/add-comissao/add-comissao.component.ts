import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Comissao } from 'src/app/models/comissao.model';
import { Venda } from 'src/app/models/venda.model';
import { ComissoesService } from 'src/app/services/comissoes.service';
import { VendasService } from 'src/app/services/vendas.service';

@Component({
  selector: 'app-add-comissao',
  templateUrl: './add-comissao.component.html',
  styleUrls: ['./add-comissao.component.css']
})
export class AddComissaoComponent implements OnInit{
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
  addComissaoRequest: Comissao = {
    id: 0,
    relatorio: '',
    notaFiscal: '',
    valor: 0,
    dataRebimento: new Date(''),
    vendaId: 0,
    venda: this.vendaNull
  }
  constructor(private comissaoService:ComissoesService, private vendasService: VendasService, private router: Router){}
  ngOnInit(): void {

  }

  addComissao(){
    this.comissaoService.addComissao(this.addComissaoRequest).subscribe({
      next: (comissao) =>{
        this.router.navigate(['comissoes']);
      }
    });
  }
}
