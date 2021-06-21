import { Component, OnInit } from '@angular/core';
import { Hosting } from 'src/models/hosting.model';
import { AnimalService } from 'src/services/animal.service';

@Component({
  selector: 'app-getHosting',
  templateUrl: './getHosting.component.html',
  styleUrls: ['./getHosting.component.scss']
})
export class GetHostingComponent implements OnInit {

  hostings: any[];

  constructor(private service: AnimalService) {
    this.hostings = [];
  }


  ngOnInit(){
    this.service.getAllHosting().subscribe((hostings: Hosting[]) => {
      console.table(hostings);
      this.hostings = hostings;
    })
  }

}
