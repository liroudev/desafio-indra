import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LivrosComponent } from './livros/livros.component';
import { NavComponent } from './nav/nav.component';
import { AutoresComponent } from './autores/autores.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { TituloComponent } from './titulo/titulo.component';

@NgModule({
  declarations: [				
    AppComponent,
      LivrosComponent,
      NavComponent,
      AutoresComponent,
      DashboardComponent,
      TituloComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
