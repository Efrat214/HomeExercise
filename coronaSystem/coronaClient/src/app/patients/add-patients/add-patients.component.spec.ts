import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPatientsComponent } from './add-patients.component';

describe('AddPatientsComponent', () => {
  let component: AddPatientsComponent;
  let fixture: ComponentFixture<AddPatientsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddPatientsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddPatientsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
