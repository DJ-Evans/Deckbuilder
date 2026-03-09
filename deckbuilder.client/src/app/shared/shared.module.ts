import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { CardSearchComponent } from './components/card-search/card-search.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [CardSearchComponent],
  imports: [CommonModule, FormsModule],
  exports: [CardSearchComponent, CommonModule],
})
export class SharedModule { }
