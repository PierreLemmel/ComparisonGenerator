import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent {

  comparison: ComparisonCreateModel = new ComparisonCreateModel();

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.reset();
  }

  onSubmit(form: NgForm) {
    console.log('submit');
    console.log(this.comparison);

    if (!form.valid) {
      return;
    }

    this.http
      .put(this.baseUrl + 'comparison/add', this.comparison)
      .subscribe(
        (res) => this.reset(),
        (err) => console.error(err)
      );

    alert("Comparaison ajoutée !");
    form.controls['body'].reset();
  }

  onResetClicked() {
    console.log('reset');
    this.reset();
  }

  private reset() {
    this.comparison.body = '';
  }

  get formValid() { return this.comparison.author && this.comparison.body }
}

export class ComparisonCreateModel {
  constructor(
    public leftHandSide: string = '',
    public rightHandSide: string = '',
    public body: string = '',
    public author: string = '',
  ) {}
}
