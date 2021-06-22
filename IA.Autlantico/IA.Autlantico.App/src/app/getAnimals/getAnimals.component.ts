import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { Animal } from 'src/models/animal.model';
import { AnimalService } from 'src/services/animal.service';

@Component({
  selector: 'app-getAnimals',
  templateUrl: './GetAnimals.component.html',
  styleUrls: ['./GetAnimals.component.scss']
})
export class GetAnimalsComponent implements OnInit {

  animals: any[];

  constructor(private service: AnimalService, private router: Router) {
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

    deleteAnimal(idAnimal: number) {
      this.service.deleteAnimal(idAnimal).subscribe(result => {
        alert("Exclusão realizada com sucesso");
        window.location.reload();
      });
    }

    editFile(animalId: number)
    {
      this.router.navigate(['/editAnimal'], { queryParams: { id: animalId } });
    }
  }
