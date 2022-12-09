import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { VendasComponent } from './components/vendas/vendas.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HttpClientModule } from '@angular/common/http';
import { AddVendaComponent } from './components/vendas/add-venda/add-venda.component';
import { FormsModule } from '@angular/forms';
import { EditVendaComponent } from './components/vendas/edit-venda/edit-venda.component';
import { ComissoesListComponent } from './components/comissoes/comissoes-list/comissoes-list.component';
import { AddComissaoComponent } from './components/comissoes/add-comissao/add-comissao.component';
import { EditComissaoComponent } from './components/comissoes/edit-comissao/edit-comissao.component';
import { ComissoesVendaComponent } from './components/vendas/comissoes-venda/comissoes-venda.component';


@NgModule({
  declarations: [
    VendasComponent,
    NavbarComponent,
    AppComponent,
    ComissoesListComponent,
    AddComissaoComponent,
    EditComissaoComponent,
    ComissoesVendaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    FormsModule,
    EditVendaComponent,
    AddVendaComponent,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
