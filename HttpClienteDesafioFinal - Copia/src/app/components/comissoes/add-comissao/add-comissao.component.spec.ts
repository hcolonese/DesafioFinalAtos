import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddComissaoComponent } from './add-comissao.component';

describe('AddComissaoComponent', () => {
  let component: AddComissaoComponent;
  let fixture: ComponentFixture<AddComissaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddComissaoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddComissaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
