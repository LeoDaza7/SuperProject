import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule, RoutingComponents } from './app-routing.module';

import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { HttpService } from './http.service';
import { AuthGuard } from './auth.guard';


@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    RoutingComponents

  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule
    
  ],
  providers: [HttpService,AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
