import { Component, OnInit } from '@angular/core';
import { DeckModel } from '../../../shared/models/deck.model';
import { DeckService } from '../../../decks/deck.service';
import { BaseComponent } from '../../../shared/base/base.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: false,
  templateUrl: './navbar.component.html',
})
export class NavbarComponent extends BaseComponent implements OnInit {
  public decks!: DeckModel[];

  constructor(
    private deckService: DeckService,
    private router: Router,
  ) {
    super();
  }

  ngOnInit(): void {
    this.deckService.GetAllDecks().subscribe({
      next: (decks) => {
        this.decks = decks;
        console.log(this.decks);
      },
    });
  }
}
