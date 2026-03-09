import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseApiService } from '../shared/base/base-api.service';
import { CardModel } from '../shared/models/card.model';

@Injectable({
  providedIn: 'root',
})
export class CardService extends BaseApiService {
  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  public GetCardsByName(cardName: string): Observable<CardModel[]> {
    return this.get<CardModel[]>(`api/card/${cardName}`);
  }
  // public GetDeck(deckId: number): Observable<DeckModel> {
  //   return this.get<DeckModel>(`aapi/deck/${deckId}`);
  // }
  //
  // public GetAllDecks(): Observable<DeckModel[]> {
  //   return this.get<DeckModel[]>('api/deck');
  // }
  //
  // public SaveDeck(deck: DeckModel): Observable<DeckModel> {
  //   return this.post<DeckModel>(`api/deck/save`, deck);
  // }
}
