import { NgModule } from '@angular/core';
import { DeckRoutingModule } from './deck-routing.module';
import { CommonModule } from '@angular/common';
import { DeckEditPageComponent } from './deck-edit-page/deck-edit-page.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [DeckEditPageComponent],
  imports: [SharedModule, DeckRoutingModule],
  exports: [SharedModule],
})
export class DeckModule { }
