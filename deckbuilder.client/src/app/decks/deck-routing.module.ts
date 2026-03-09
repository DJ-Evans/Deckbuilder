import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DeckEditPageComponent } from './deck-edit-page/deck-edit-page.component';

const routes: Routes = [
  //   {
  //     path: '', component: DeckListPageComponent
  //   },
  {
    path: 'add',
    component: DeckEditPageComponent,
  },
  {
    path: 'edit/:deckId',
    component: DeckEditPageComponent,
  },
  {
    path: '**',
    redirectTo: '',
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DeckRoutingModule {}
