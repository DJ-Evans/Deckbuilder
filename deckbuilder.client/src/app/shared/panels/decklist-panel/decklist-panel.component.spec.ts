import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DecklistPanelComponent } from './decklist-panel.component';

describe('DecklistPanelComponent', () => {
  let component: DecklistPanelComponent;
  let fixture: ComponentFixture<DecklistPanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DecklistPanelComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DecklistPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
