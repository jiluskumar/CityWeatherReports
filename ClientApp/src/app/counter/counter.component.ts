import { Component, Inject } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public forecasts: WeatherForecast = {};
  public searchModel : CitySearchModel= {};
  
  private cityid = 0;
  public searchResponse : any;
  constructor(
    
    private formBuilder: FormBuilder,
    private http: HttpClient, @Inject('BASE_URL') private baseUrl: string
  ) { }
  public currentCount = 0;
  
  checkoutForm = this.formBuilder.group({
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

  searchForm = this.formBuilder.group({
    cityName: ''
  })

  public onSubmit() {
    //this.forecasts.cityId = 0;
    this.forecasts.dateEstablisted = new Date();
    this.http.post<number>(this.baseUrl + 'weatherforecast/saveCity', this.forecasts).subscribe(result => {
      this.cityid = result;
    }, error => console.error(error));
  }

  public onSearch() {
    const url = `q=${this.searchModel.cityName}&appid=439d4b804bc8187953eb36d2a8c26a02&units=metric`;
    this.http.get<any>('https://openweathermap.org/data/2.5/find?'+url).subscribe(result => {
      if(result.count > 0){
        this.searchResponse = result.list;
      }
    }, error => console.error(error));
  }

  public calculateTemp(temp: string){
    return Math.round(parseFloat(temp) /20) ;
  }

  public onSearchSelect(city:string,country:string,temp:string){
    this.forecasts.cityName = city;
    this.forecasts.twoDigitCountryCode = country;
    this.forecasts.cityWeather = this.calculateTemp(temp);
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
interface CitySearchModel{
  cityName?: String;
}
