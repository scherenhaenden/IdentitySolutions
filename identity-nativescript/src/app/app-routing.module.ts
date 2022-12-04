import { NgModule } from '@angular/core'
import { Routes } from '@angular/router'
import { NativeScriptRouterModule } from '@nativescript/angular'

import { ItemsComponent } from './item/items.component'
import { ItemDetailComponent } from './item/item-detail.component'
import { HomeModule } from './modules/home/home.module';
import { LoginModule } from './modules/login/login.module'




const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  /*{ path: 'items', component: ItemsComponent },
  { path: 'item/:id', component: ItemDetailComponent },*/
  {
    path: 'home',
    loadChildren: () => import('./modules/home/home.module').then(m => m.HomeModule)
  },
  {
    path: 'login',
    loadChildren: () => import('./modules/login/login.module').then(m => m.LoginModule)
  }

]

@NgModule({
  imports: [NativeScriptRouterModule.forRoot(routes)],
  exports: [NativeScriptRouterModule],
})
export class AppRoutingModule {}
