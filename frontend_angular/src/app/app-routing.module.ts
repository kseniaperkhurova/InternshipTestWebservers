import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FillInComponent } from './components/fill-in/fill-in.component';
import { AppComponent } from './app.component';
import { AddPractitionerComponent } from './components/add-practitioner/add-practitioner.component';
import { PractitionersComponent } from './components/practitioners/practitioners.component';
import { UpdatePractitionerComponent } from './components/update-practitioner/update-practitioner.component';
import { DeletePractitionerComponent } from './components/delete-practitioner/delete-practitioner.component';
const routes: Routes = [
  {
    path: '',
    component: FillInComponent,
  },
  { path: 'addpractitioner', component: AddPractitionerComponent },
  { path: 'practitioners', component: PractitionersComponent },
  { path: 'updatepractitioners', component: UpdatePractitionerComponent },
  { path: 'deletepractitioners', component: DeletePractitionerComponent },
  {
    path: '**',
    redirectTo: '',
    component: AppComponent,
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
