import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AutoresComponent } from './autores/autores.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LivrosComponent } from './livros/livros.component';

const routes: Routes = [
  {path:'',redirectTo:'dashboard',pathMatch:'full'},
  {path:'dashboard', component:DashboardComponent},
  {path:'livros',component:LivrosComponent},
  {path:'autores',component:AutoresComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
