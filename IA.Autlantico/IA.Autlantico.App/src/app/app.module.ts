import { AppRoutingModule } from './app-routing.module';
import { SaveAnimalComponent } from './saveAnimal/saveAnimal.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { GetAnimalsComponent } from './getAnimals/getAnimals.component';
import { IndexComponent } from './index/index.component';
import { GetHostingComponent } from './getHosting/getHosting.component';

@NgModule({
  declarations: [		
    AppComponent,
    SaveAnimalComponent,
      GetAnimalsComponent,
      IndexComponent,
      GetHostingComponent
   ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
