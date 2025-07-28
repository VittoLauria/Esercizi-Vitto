import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AcquistoDetail } from './acquisto-detail';

describe('AcquistoDetail', () => {
  let component: AcquistoDetail;
  let fixture: ComponentFixture<AcquistoDetail>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AcquistoDetail]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AcquistoDetail);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
