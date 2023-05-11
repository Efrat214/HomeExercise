import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowPatientsComponent } from './show-patients.component';

describe('ShowPatientsComponent', () => {
  let component: ShowPatientsComponent;
  let fixture: ComponentFixture<ShowPatientsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowPatientsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowPatientsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
