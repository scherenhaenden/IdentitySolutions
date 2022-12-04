// src/app/features/home/home.component.ts
import { Component } from '@angular/core';
import { Button, EventData, SearchBar, TextField } from '@nativescript/core';
import * as application from "@nativescript/core/application"
import { requestPermissions, requestCameraPermissions } from '@nativescript/camera';

@Component({
  moduleId: module.id,
  selector: 'ns-home',
  styleUrls: ['./home.component.css'],
  templateUrl: 'home.component.html'
})
export class HomeComponent {

  isLoggingIn = true;
  pause = true;
  askedForPermission = false;
  status = "Not started";

  toggleForm() {
    this.isLoggingIn = !this.isLoggingIn;
  }
  onScanResult(evt) {
    console.log(`onScanResult: ${evt.text} (${evt.format})`);
  }

  submit() {
    if (this.isLoggingIn) {
        // Perform the login
    } else {
        // Perform the registration
    }
  }

  public initRequesForCameraPermission() {
    if (!this.askedForPermission) {
      this.askedForPermission = true;
      requestCameraPermissions().then(
        () => {
          console.log("Permissions granted!");
          this.status = "Permissions granted!";
          this.askedForPermission = true;
        },
        () => {
          console.log("Permissions revoked!");
          this.status = "Permissions revoked!";
          this.askedForPermission = false;
        }
      );
    }
  }

  public isItemVisible: boolean;

    constructor() {
        if (application.android) {
            console.log("We are running on Android device!");
            this.isItemVisible = true;
        } else if (application.ios) {
            console.log("We are running on iOS device");
            this.isItemVisible = false;
        }
    }

    searchPhrase: string;

    onSubmit(args) {
        const searchBar = args.object as SearchBar;
        console.log(`Searching for ${searchBar.text}`);
    }

    onTextChanged(args) {
        const searchBar = args.object as SearchBar;
        console.log(`Input changed! New value: ${searchBar.text}`);
    }

    onClear(args) {
        const searchBar = args.object as SearchBar;
        console.log(`Clear event raised`);
    }

  public onTap(args: EventData) {
      let button = args.object as Button;
      // execute your custom logic here...
  }

  name = "";

  onReturnPress(args) {
      // returnPress event will be triggered when user submits a value
      let textField = <TextField>args.object;

      // Gets or sets the placeholder text.
      console.log(textField.hint);
      // Gets or sets the input text.
      console.log(textField.text);
      // Gets or sets the secure option (e.g. for passwords).
      console.log(textField.secure);

      // Gets or sets the soft keyboard type. Options: "datetime" | "phone" | "number" | "url" | "email"
      console.log(textField.keyboardType);
      // Gets or sets the soft keyboard return key flavor. Options: "done" | "next" | "go" | "search" | "send"
      console.log(textField.returnKeyType);
      // Gets or sets the autocapitalization type. Options: "none" | "words" | "sentences" | "allcharacters"
      console.log(textField.autocapitalizationType);

      // Gets or sets a value indicating when the text property will be updated.
      console.log(textField.updateTextTrigger);
      // Gets or sets whether the instance is editable.
      console.log(textField.editable);
      // Enables or disables autocorrection.
      console.log(textField.autocorrect);
      // Limits input to a certain number of characters.
      console.log(textField.maxLength);

      setTimeout(() => {
          textField.dismissSoftInput(); // Hides the soft input method, ususally a soft keyboard.
      }, 100);
  }

  onFocus(args) {
      // focus event will be triggered when the users enters the TextField
      let textField = <TextField>args.object;
  }

  onBlur(args) {
      // blur event will be triggered when the user leaves the TextField
      let textField = <TextField>args.object;
  }
}
