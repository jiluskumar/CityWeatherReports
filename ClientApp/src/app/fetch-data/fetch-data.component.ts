import { Component, Inject } from '@angular/core';
import { HttpClient,HttpParams } from '@angular/common/http';
import {Router} from '@angular/router';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[] = [];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,private router: Router) {
    http.get<WeatherForecast[]>(baseUrl + 'weatherforecast/get').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }

  public onEditClick(id: number) {
    let clityid: number;
    clityid = id;
    this.router.navigateByUrl('edit-city?id='+clityid);
  }
  public onDeleteClick(id: number) {
    let cityid: number;
    cityid = id;
    let param = new HttpParams();
    param.append("cityId", cityid.toString());
    const url = `${id}`;
    this.http.delete<boolean>(this.baseUrl + 'weatherforecast/deleteCity?cityId='+url).subscribe(result => {
      let response = result;
    }, error => console.error(error));
  }
}

interface WeatherForecast {
  cityId: number;
  touristRating?: number;
  estimatedPopulation?: number;
  twoDigitCountryCode?: string;
  threeDigitCountryCode?: string;
  cityWeather?: number;
  dateEstablisted?: Date;
  cityName?: string;
  state?: string;
  country?: string;
  createdDate?: Date;
  updatedDate?: Date;
}
