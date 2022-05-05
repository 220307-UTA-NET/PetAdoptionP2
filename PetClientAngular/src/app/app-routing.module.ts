import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PetsComponent } from './pets/pets.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { PetDetailComponent } from './pet-detail/pet-detail.component';
import { AccountsComponent } from './accounts/accounts.component';

const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'login', component: AccountsComponent },
  {
    path: 'pets',
    component: PetsComponent
  },
  {
    path: 'dashboard',
    component: DashboardComponent
  },
  {
    path: 'pet/:id',
    component: PetDetailComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }




