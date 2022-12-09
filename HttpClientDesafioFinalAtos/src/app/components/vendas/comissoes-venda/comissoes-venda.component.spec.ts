import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComissoesVendaComponent } from './comissoes-venda.component';

describe('ComissoesVendaComponent', () => {
  let component: ComissoesVendaComponent;
  let fixture: ComponentFixture<ComissoesVendaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ComissoesVendaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ComissoesVendaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
