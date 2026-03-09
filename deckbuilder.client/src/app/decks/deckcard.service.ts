import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseApiService } from '../shared/base/base-api.service';
import { DeckModel } from '../shared/models/deck.model';

@Injectable({
  providedIn: 'root',
})
export class DeckCardService extends BaseApiService {
  constructor(httpClient: HttpClient) {
    super(httpClient);
  }
  public AddDeckCard(deckId: number, cardId: number): Observable<Boolean> {
    return this.post<Boolean>(`api/deckCard/Add/${deckId}/${cardId}`, {});
  }
}
