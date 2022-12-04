import { Component, OnInit } from "@angular/core";



@Component({
  moduleId: module.id,
  selector: 'ns-login',
  styleUrls: ['./login.component.css'],
  templateUrl: 'login.component.html'
})
export class LoginComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}

  isLoggingIn = true;

  toggleForm() {
    this.isLoggingIn = !this.isLoggingIn;
  }

  submit() {
    if (this.isLoggingIn) {
        // Perform the login
    } else {
        // Perform the registration
    }
  }

}
