import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule, RoutingComponents } from './app-routing.module';

import { AppComponent } from './app.component';
import { FormsModule} from '@angular/forms'
import { HttpModule } from '@angular/http'

import { NavBarComponent } from './nav-bar/nav-bar.component';
import { ShippingOptionsComponent } from './shipping-options/shipping-options.component';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    RoutingComponents,
    ShippingOptionsComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpModule,
    ToastrModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
