import { HttpClient } from '@angular/common/http';
import { AnimalService } from './../../services/animal.service';
import { Component, OnInit } from '@angular/core';
import { Animal } from 'src/models/animal.model';
import { Router } from "@angular/router";

@Component({
  selector: 'app-saveAnimal',
  templateUrl: './saveAnimal.component.html',
  styleUrls: ['./saveAnimal.component.scss']
})

export class SaveAnimalComponent implements OnInit {

  constructor(private service: AnimalService, private router: Router) {

  }

  ngOnInit(){
    this.cleanfields();
  }

  title = 'SaveAnimal';
  namePet: string = '';
  internationMotive: string ='';
  status: string='0';
  nameTutor:string='';
  address: string='';
  phoneNumber:string = '';
  statusName = undefined;

  save(){

    const animalToSave:Animal =
        {
            name : this.namePet,
            internationMotive : this.internationMotive,
            status : parseInt(this.status),
            nameTutor : this.nameTutor,
            address : this.address,
            phoneNumber : this.phoneNumber,
            statusName : this.statusName
           };

    this.service.save(animalToSave).subscribe(result => {
      alert("Animal cadastrado. Número do alojamento: " + result)
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
