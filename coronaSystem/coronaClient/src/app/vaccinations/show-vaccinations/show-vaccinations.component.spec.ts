import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowVaccinationsComponent } from './show-vaccinations.component';

describe('ShowVaccinationsComponent', () => {
  let component: ShowVaccinationsComponent;
  let fixture: ComponentFixture<ShowVaccinationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowVaccinationsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowVaccinationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
