import { Component } from '@angular/core';
import { DataItemService } from '../services/dataitem.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  dataItems$;
  constructor(private dataItemService: DataItemService) { }
  fetchData() {
    this.dataItems$ = this.dataItemService.fetchDataItems();
  }
}
