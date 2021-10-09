import { Component } from '@angular/core';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { FormService } from "./form.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'sample-app';
  formData = this.formBuilder.group({
    firstname: '',
    lastname: ''
  });
  constructor(
    private formBuilder: FormBuilder,
    private formService: FormService
  ) { }

  onSubmit = (e: any) => {
    e.preventDefault();
    this.formService.postForm(this.formData.value).subscribe((data: any) => {
      alert("Saved")
      this.formData.reset();
  })
  }
}
