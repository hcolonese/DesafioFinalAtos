import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComissoesListComponent } from './comissoes-list.component';

describe('ComissoesListComponent', () => {
  let component: ComissoesListComponent;
  let fixture: ComponentFixture<ComissoesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ComissoesListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ComissoesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
