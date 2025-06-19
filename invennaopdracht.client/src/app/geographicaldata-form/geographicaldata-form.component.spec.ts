import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GeographicaldataFormComponent } from './geographicaldata-form.component';

describe('GeographicaldataFormComponent', () => {
  let component: GeographicaldataFormComponent;
  let fixture: ComponentFixture<GeographicaldataFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GeographicaldataFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GeographicaldataFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
