import { Component, NgModule, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Venda } from 'src/app/models/venda.model';
import { compileNgModule } from '@angular/compiler';
import { VendasService } from 'src/app/services/vendas.service';
import {RouterModule} from '@angular/router';


@Component({
  selector: 'app-vendas-list',
  templateUrl: './vendas-list.component.html',
  styleUrls: ['./vendas-list.component.css'],
  standalone: true,
  imports: [
    CommonModule,RouterModule
  ],
})



export class VendasListComponent implements OnInit{
    listaVendas: Venda[] = [];
  constructor(private vendasService: VendasService){}

  ngOnInit(): void {
    this.vendasService.getAllVendas().subscribe({
      next : (vendas) => {
        this.listaVendas = vendas;
      },
      error: (response) => {
        console.log(response);
      }
    });
  }
}
