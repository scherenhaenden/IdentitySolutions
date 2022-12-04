import { LoginComponent } from './login.component';
import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core'
import { NativeScriptCommonModule } from '@nativescript/angular'
import { LoginRoutingModule } from './login-routing.module';


@NgModule({
  imports: [NativeScriptCommonModule, LoginRoutingModule],
  declarations: [LoginComponent],
  exports: [LoginComponent],
  schemas: [NO_ERRORS_SCHEMA]
})
export class LoginModule {}
