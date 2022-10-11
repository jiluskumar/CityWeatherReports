import { Component, OnInit,Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient, HttpParams } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';


@Component({
  selector: 'app-edit-city',
  templateUrl: './edit-city.component.html',
  styleUrls: ['./edit-city.component.css']
})
export class EditCityComponent implements OnInit {
public forecast : WeatherForecast = {};

private cityid = 0;
  constructor( private router: Router,
    private activeRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { 
      activeRoute.queryParams.subscribe(params => {
        const url = `${params.id}`;
        http.get<WeatherForecast>(baseUrl + 'weatherforecast/getCityById?cityId='+url).subscribe(result => {
          this.forecast = result;
        }, error => console.error(error));
  })
    }

  ngOnInit(): void {
    
  }
  editCityForm = this.formBuilder.group({
    cityName: '',
    state: '',
    country: '',
    address: '',
    touristRating: '',
    twoDigitCountryCode: '',
    threeDigitCountryCode: '',
    cityWeather: '',
    estimatedPopulation: '',
    dateEstablisted: ''
  });
  public onUpdate () {
    this.forecast.dateEstablisted = new Date(1980,7,2);
    this.http.put<number>(this.baseUrl + 'weatherforecast/editCity', this.forecast).subscribe(result => {
      this.cityid = result;
    }, error => console.error(error));
  }

}
interface WeatherForecast {
  cityId?: number;
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
