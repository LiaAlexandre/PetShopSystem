import { Component, OnInit } from '@angular/core';
import { Animal } from 'src/models/animal.model';
import { AnimalService } from 'src/services/animal.service';
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: 'app-editAnimal',
  templateUrl: './editAnimal.component.html',
  styleUrls: ['./editAnimal.component.scss']
})
export class EditAnimalComponent implements OnInit {

  constructor(private service: AnimalService, private route: ActivatedRoute, private router: Router) {

  }
  animalId: string ='';
  title = 'EditAnimal';
  namePet: string = '';
  internationMotive: string ='';
  status: string='0';
  nameTutor:string='';
  address: string='';
  phoneNumber:string = '';
  statusName = undefined;


  ngOnInit() {
    this.cleanfields();
    this.route.queryParams
      .subscribe(params => {
        this.animalId = params["id"];

        this.service.getAnimal(parseInt(this.animalId)).subscribe(result => {
          this.namePet = result.name;
          this.nameTutor = result.nameTutor;
          this.phoneNumber = result.phoneNumber;
          this.address = result.address;
          this.internationMotive = result.internationMotive;
        });
      }
    );
  }
    update(){

      const animalToUpdate:Animal =
          {
              id: parseInt(this.animalId),
              name : this.namePet,
              internationMotive : this.internationMotive,
              status : parseInt(this.status),
              nameTutor : this.nameTutor,
              address : this.address,
              phoneNumber : this.phoneNumber,
              statusName : this.statusName
             };

      this.service.updateAnimal(animalToUpdate).subscribe(result => {
        alert("Editado com sucesso.");
        this.router.navigate(['/getAnimals']);
      });

      this.cleanfields();
    }

    cleanfields()
    {
      this.namePet = '';
      this.internationMotive= '';
      this.status = '0';
      this.nameTutor = '';
      this.address ='';
      this.phoneNumber = '';
    }
  }
