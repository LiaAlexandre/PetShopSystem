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
  status: string='0';
  nameTutor:string='';
  address: string='';
  phoneNumber:string = '';
  statusName = undefined;

  save(){

    const animalToSave:Animal =
        {
            Name : this.namePet,
            InternationMotive : this.internationMotive,
            Status : parseInt(this.status),
            NameTutor : this.nameTutor,
            Address : this.address,
            PhoneNumber : this.phoneNumber,
            StatusName : this.statusName
           };

    this.service.save(animalToSave).subscribe(result => {
      console.log(result);
    });
  }
}
