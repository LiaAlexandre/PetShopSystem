import { HttpClient } from '@angular/common/http';
import { AnimalService } from './../../services/animal.service';
import { Component, OnInit } from '@angular/core';
import { Animal } from 'src/models/animal.model';

@Component({
  selector: 'app-saveAnimal',
  templateUrl: './saveAnimal.component.html',
  styleUrls: ['./saveAnimal.component.scss']
})

export class SaveAnimalComponent implements OnInit {

  constructor(private service: AnimalService) {

  }

  ngOnInit(){
  }

  title = 'SaveAnimal';
  namePet: string = '';
  internationMotive: string ='';
  status: number=0;
  nameTutor:string='';
  address: string='';
  phoneNumber:string = '';

  save(){

    const animalToSave:Animal =
        {
            Name : this.namePet,
            InternationMotive : this.internationMotive,
            Status : this.status.toString(),
            NameTutor : this.nameTutor,
            Address : this.address,
            PhoneNumber : this.phoneNumber
           };

    this.service.save(animalToSave).subscribe(result => {
      console.log(result);
    });
  }
}
