import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IWeather } from "./IWeather";
import { map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
  })

  export class WeatherService {
    baseUrl = 'https://localhost:5001/Weatherforecast/';
  
    constructor(
      private http: HttpClient
    ) { }

    getWeatherforecast(): Observable<IWeather[]> {
        return this.http.get<IWeather[]>(this.baseUrl);
  
    }
}
