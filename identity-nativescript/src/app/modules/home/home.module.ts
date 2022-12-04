import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core'
import { NativeScriptCommonModule } from '@nativescript/angular'
import { HomeRoutingModule } from './home-routing.module'
import { HomeComponent } from './home.component'
import { registerElement } from '@nativescript/angular';
//registerElement("BarcodeScanner", () => require("nativescript-barcodescanner").BarcodeScannerView);
import { BarcodeView } from '@nativescript-community/ui-barcodeview';
registerElement('BarcodeView', () => BarcodeView);

@NgModule({
  imports: [NativeScriptCommonModule, HomeRoutingModule],
  declarations: [HomeComponent],
  exports: [HomeComponent],
  schemas: [NO_ERRORS_SCHEMA]
})
export class HomeModule {}
