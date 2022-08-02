import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-country-list',
  templateUrl: './country-list.component.html',
  styleUrls: ['./country-list.component.css']
})
export class CountryListComponent implements OnInit {
    public countrylistdata: CountryList[];

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
    {
        http.get<CountryList[]>(baseUrl + "result").subscribe(result => {
            this.countrylistdata = result;
        }, error => console.error(error));
    }

  ngOnInit() {
  }

}

interface CountryList {
    name: string;
    region: string;
    subregion: string;
}