import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseApiService } from '../shared/base/base-api.service';
import { DeckModel } from '../shared/models/deck.model';

@Injectable({
  providedIn: 'root',
})
export class DeckService extends BaseApiService {
  constructor(httpClient: HttpClient) {
    super(httpClient);
  }
  public GetDeck(deckId: number): Observable<DeckModel> {
    return this.get<DeckModel>(`api/deck/${deckId}`);
  }

  public GetAllDecks(): Observable<DeckModel[]> {
    return this.get<DeckModel[]>('api/deck');
  }

  public SaveDeck(deck: DeckModel): Observable<DeckModel> {
    return this.post<DeckModel>(`api/deck/save`, deck);
  }
}
