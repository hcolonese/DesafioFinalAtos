import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CommonModule } from '@angular/common';
import { VendasListComponent } from './vendas-list.component';

describe('VendasListComponent', () => {
  let component: VendasListComponent;
  let fixture: ComponentFixture<VendasListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VendasListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VendasListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
