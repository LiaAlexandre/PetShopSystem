import { GetHostingComponent } from './getHosting/getHosting.component';
import { SaveAnimalComponent } from './saveAnimal/saveAnimal.component';
import { RouterModule, Routes } from "@angular/router";
import { GetAnimalsComponent } from './getAnimals/getAnimals.component';
import { NgModule } from '@angular/core';

export const routes: Routes = [
  { path: '', redirectTo: 'getAnimals', pathMatch: 'full' },
  { path: 'saveAnimal', component: SaveAnimalComponent },
  { path: 'getAnimals', component: GetAnimalsComponent },
  { path: 'getHosting', component: GetHostingComponent }

];

@NgModule({
  imports:[RouterModule.forRoot(routes)],
  exports:[RouterModule]
})
export class AppRoutingModule { }
