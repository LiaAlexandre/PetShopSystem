import { Component, OnInit } from '@angular/core';
import { Animal } from 'src/models/animal.model';
import { AnimalService } from 'src/services/animal.service';

@Component({
  selector: 'app-getAnimals',
  templateUrl: './GetAnimals.component.html',
  styleUrls: ['./GetAnimals.component.scss']
})
export class GetAnimalsComponent implements OnInit {

  animals: any[];

  constructor(private service: AnimalService) {
    this.animals = [];
  }

  namePet: string = '';

  ngOnInit(){
    this.service.getAll().subscribe((animals: Animal[]) => {
      console.table(animals);
      this.animals = animals;
    })
  }

    getByName() {
    this.service.getByName(this.namePet).subscribe((animals: Animal[]) => {
      console.table(animals);
      this.animals = animals;
    })
    }
  }
