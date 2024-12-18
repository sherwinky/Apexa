import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdvisorListComponent } from './components/advisor-list/advisor-list.component';

const routes: Routes = [
   { path: '', redirectTo: '/search-advisor', pathMatch: 'full' },
   {path: 'search-advisor', component: AdvisorListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
