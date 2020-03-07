import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-consult',
  templateUrl: './consult.component.html',
  styleUrls: ['./consult.component.css']
})
export class ConsultComponent {
  public comparisons: Comparison[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Comparison[]>(baseUrl + 'comparison').subscribe(result => {
      this.comparisons = result;
    }, error => console.error(error));
  }
}

interface Comparison {
  leftHandSide: string,
  rightHandSide: string,
  body: string
}
