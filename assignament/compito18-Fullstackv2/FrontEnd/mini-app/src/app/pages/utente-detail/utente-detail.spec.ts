import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UtenteDetail } from './utente-detail';

describe('UtenteDetail', () => {
  let component: UtenteDetail;
  let fixture: ComponentFixture<UtenteDetail>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UtenteDetail]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UtenteDetail);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
