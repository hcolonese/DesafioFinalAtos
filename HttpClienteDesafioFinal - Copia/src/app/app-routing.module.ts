
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddComissaoComponent } from './components/comissoes/add-comissao/add-comissao.component';
import { ComissoesListComponent } from './components/comissoes/comissoes-list/comissoes-list.component';
import { EditComissaoComponent } from './components/comissoes/edit-comissao/edit-comissao.component';
import { AddVendaComponent } from './components/vendas/add-venda/add-venda.component';
import { EditVendaComponent } from './components/vendas/edit-venda/edit-venda.component';
import { VendasListComponent } from './components/vendas/vendas-list/vendas-list.component';
import { VendasComponent } from './components/vendas/vendas.component';



const routes: Routes = [
  {path:'', component: VendasListComponent},
  {path:'vendas', component: VendasListComponent},
  {path:'vendas/add', component: AddVendaComponent},
  {path:'vendas/edit/:id', component: EditVendaComponent},
  {path:'comissoes', component: ComissoesListComponent},
  {path:'comissoes/add', component: AddComissaoComponent},
  {path:'comissoes/edit/:id', component: EditComissaoComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
