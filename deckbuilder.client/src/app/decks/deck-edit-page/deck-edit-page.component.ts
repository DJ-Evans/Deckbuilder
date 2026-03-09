import { Component, OnInit } from '@angular/core';
import { DeckService } from '../deck.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BaseComponent } from '../../shared/base/base.component';
import { DeckModel } from '../../shared/models/deck.model';
import { CardModel } from '../../shared/models/card.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-deck-edit-page',
  templateUrl: './deck-edit-page.component.html',
  standalone: false,
})
export class DeckEditPageComponent extends BaseComponent implements OnInit {
  public form!: FormGroup;
  public deck?: DeckModel;
  public deckId?: number;
  public userId?: number;
  public deckName?: string;
  public description?: string;
  public colors?: string;
  public format?: string;
  public cardList?: CardModel[] = [];

  public instants?: CardModel[] = [];
  public sorceries?: CardModel[] = [];
  public creatures?: CardModel[] = [];
  public artifacts?: CardModel[] = [];
  public enchantments?: CardModel[] = [];
  public planeswalkers?: CardModel[] = [];
  public lands?: CardModel[] = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private deckService: DeckService,
  ) {
    super();
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((param) => {
      this.deckId = param.get('deckId') as unknown as number;
    });

    if (this.deckId) {
      this.deckService.GetDeck(this.deckId).subscribe({
        next: (editDeck) => {
          this.deck = editDeck;
          this.buildDeckForm();
        },
        error: (error) => {
          this.handleErrorResult(error);
        },
      });
    } else {
      this.deck = new DeckModel();
      this.buildDeckForm();
    }
  }

  private buildDeckForm(): void {
    this.form = this.formBuilder.group({
      Name: [this.deck?.deckName, Validators.required],
      Description: [this.deck?.description, Validators.required],
      Format: [this.deck?.format, Validators.required],
    });
    this.loaded = true;
  }

  public onSubmit(): void {
    if (!this.form.valid) {
      return;
    }
    var deck = {
      deckId: this.deckId,
      deckName: this.form.get('DeckName')?.value,
      description: this.form.get('Description')?.value,
      format: this.form.get('Format')?.value,
    } as DeckModel;
    this.deckService.SaveDeck(deck).subscribe({
      next: (result) => {
        this.router.navigate(['../'], { relativeTo: this.route });
        console.log(result);
      },
      error: (error) => {
        this.handleErrorResult(error);
      },
    });
  }

  public addCard(card: CardModel) {
    this.cardList?.push(card);
    this.sortCard(card);
  }

  public sortCard(card: CardModel) {
    var cardType = card.cardType;
    if (cardType.includes('Instant')) {
      this.instants?.push(card);
    } else if (cardType.includes('Sorcery')) {
      this.sorceries?.push(card);
    } else if (cardType.includes('Creature')) {
      this.creatures?.push(card);
    } else if (cardType.includes('Artifact')) {
      this.artifacts?.push(card);
    } else if (cardType.includes('Enchantment')) {
      this.enchantments?.push(card);
    } else if (cardType.includes('Planeswalker')) {
      this.planeswalkers?.push(card);
    } else if (cardType.includes('Land')) {
      this.lands?.push(card);
    }
  }
}
