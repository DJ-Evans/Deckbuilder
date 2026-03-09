import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { CardService } from '../../../cards/card.service';
import { BaseComponent } from '../../base/base.component';
import { CardModel } from '../../models/card.model';

@Component({
  selector: 'app-card-search',
  standalone: false,
  templateUrl: './card-search.component.html',
})
export class CardSearchComponent extends BaseComponent implements OnInit {
  public searchResults: CardModel[] = [];
  public currentSearch: string = '';

  constructor(private cardService: CardService) {
    super();
  }

  ngOnInit(): void { }

  updateSearch(event: Event) {
    this.currentSearch = (event.target as HTMLInputElement).value;
    if (this.currentSearch.length >= 3) {
      this.searchCard(this.currentSearch);
    } else {
      this.searchResults = [];
    }
  }

  searchCard(cardName: string) {
    this.cardService.GetCardsByName(cardName).subscribe({
      next: (result) => {
        this.searchResults = result;
      },
      error: (error) => {
        this.errorMessage = error.message;
        this.showError = true;
      },
    });
  }

  selectResult(card: CardModel) {
    this.currentSearch = card.cardName;
    this.searchResults = [];
    console.log('Selected card:', card);
  }

  @Output() cardClicked: EventEmitter<CardModel> =
    new EventEmitter<CardModel>();

  onCardClick(card: CardModel) {
    this.cardClicked.emit(card);
    this.searchResults = [];
    this.currentSearch = '';
  }
}
