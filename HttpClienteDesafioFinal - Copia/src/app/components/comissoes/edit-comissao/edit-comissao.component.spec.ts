import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditComissaoComponent } from './edit-comissao.component';

describe('EditComissaoComponent', () => {
  let component: EditComissaoComponent;
  let fixture: ComponentFixture<EditComissaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditComissaoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditComissaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
