import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddVaccinationsComponent } from './add-vaccinations.component';

describe('AddVaccinationsComponent', () => {
  let component: AddVaccinationsComponent;
  let fixture: ComponentFixture<AddVaccinationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddVaccinationsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddVaccinationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
