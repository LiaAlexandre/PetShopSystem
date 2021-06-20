import { SaveAnimalComponent } from './saveAnimal/saveAnimal.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { GetAnimalsComponent } from './getAnimals/getAnimals.component';

@NgModule({
  declarations: [
    AppComponent,
    SaveAnimalComponent,
      GetAnimalsComponent
   ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
