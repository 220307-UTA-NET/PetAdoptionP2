import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';  // <-- NgModel lives here
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { PetsComponent } from './pets/pets.component';
import { PetDetailComponent } from './pet-detail/pet-detail.component';
import { MessagesComponent } from './messages/messages.component';
import { AppRoutingModule } from './app-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AccountsComponent } from './accounts/accounts.component';
import { RegisterComponent } from './accounts/register/register.component';
import { LoginComponent } from './accounts/login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    PetsComponent,
    PetDetailComponent,
    MessagesComponent,
    DashboardComponent,
    AccountsComponent,
    RegisterComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
