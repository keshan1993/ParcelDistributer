import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GoodsTypeFormComponent } from './goods-type-form.component';

describe('GoodsTypeFormComponent', () => {
  let component: GoodsTypeFormComponent;
  let fixture: ComponentFixture<GoodsTypeFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GoodsTypeFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GoodsTypeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
