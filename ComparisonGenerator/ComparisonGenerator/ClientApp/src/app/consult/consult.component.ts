import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-consult',
  templateUrl: './consult.component.html',
  styleUrls: ['./consult.component.css']
})
export class ConsultComponent {
  public comparisons: ComparisonReadModel[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ComparisonReadModel[]>(baseUrl + 'comparison').subscribe(result => {
      this.comparisons = result;
    }, error => console.error(error));
  }
}

export class ComparisonReadModel {
  constructor(
    public id: string,
    public content: string,
    public author: string)
  { }
}
