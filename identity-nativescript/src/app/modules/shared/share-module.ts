import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { NativeScriptCommonModule } from '@nativescript/angular';
import { NavBar } from './components/nav-bar/nav-bar.component';



@NgModule({
  imports: [NativeScriptCommonModule],
  declarations: [NavBar],
  exports: [NavBar],
  schemas: [NO_ERRORS_SCHEMA]
})
export class ShareModule {
}
