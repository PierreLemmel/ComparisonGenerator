import { Component, Inject } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { throwError } from 'rxjs';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent {

  compForm;

  constructor(private formBuilder: FormBuilder, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.compForm = this.formBuilder.group({
      leftHandSide: new FormControl(),
      rightHandSide: new FormControl(),
      body: new FormControl(),
      author: new FormControl(),
    });
  }

  onSubmit(data) {

    if (this.compForm.invalid) {
      return;
    }

    console.log('submit');
    console.log(data);

    this.http
      .put(this.baseUrl + 'comparison/add', data)
      .subscribe(
        (res) => console.log(res),
        (err) => console.error(err)
      );
  }

  onResetClicked() {
    console.log('reset');

    this.compForm.get('body').reset();
  }

  get lhs() { return this.compForm.get('leftHandSide'); }
  get rhs() { return this.compForm.get('rightHandSide'); }
  get body() { return this.compForm.get('body'); }
  get author() { return this.compForm.get('author'); }
}
