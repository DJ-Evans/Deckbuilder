import { Component, Input, OnInit } from '@angular/core';
import { DeckModel } from '../../models/deck.model';
import { DeckService } from '../../../decks/deck.service';
import { BaseComponent } from '../../base/base.component';

@Component({
  selector: 'app-decklist-panel',
  standalone: false,
  templateUrl: './decklist-panel.component.html',
  styles: ``,
})
export class DecklistPanelComponent extends BaseComponent implements OnInit {
  @Input() userId!: string;
  public decks!: DeckModel[];

  constructor(private deckService: DeckService) {
    super();
  }

  ngOnInit(): void {
    this.deckService.GetAllDecks().subscribe({
      next: (decks) => {
        this.decks = decks;
        console.log(this.decks);
      },
      error: (error) => {
        this.errorMessage = error.message;
        this.showError = true;
      },
    });
  }
}
