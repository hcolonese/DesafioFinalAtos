import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { Venda } from 'src/app/models/venda.model';
import { VendasService } from 'src/app/services/vendas.service';

@Component({
  selector: 'app-add-venda',
  templateUrl: './add-venda.component.html',
  styleUrls: ['./add-venda.component.css'],
  standalone: true,
  imports: [
    FormsModule
  ],
})
export class AddVendaComponent implements OnInit{
  addVendaRequest: Venda = {
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
  constructor(private vendaService: VendasService, private router: Router){

  }
  ngOnInit(): void {
      
  }

  addVenda(){
    this.vendaService.addVenda(this.addVendaRequest).subscribe({
      next: (venda) =>{
        this.router.navigate(['vendas']);
      }
    });
  }
}
