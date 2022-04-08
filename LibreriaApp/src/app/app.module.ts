import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { ListaLibrosComponent } from './components/lista-libros/lista-libros.component';
import { ListaAutoresComponent } from './components/lista-autores/lista-autores.component';

import { LoginComponent } from './components/login/login.component';
import { AutorService } from './services/autor.service';
import { LibroService } from './services/libro.service';
import { LoginService } from './services/login.service';
import { UsuarioService } from './services/usuario.service';
import {ToastModule} from 'primeng/toast';
import {TableModule} from 'primeng/table';



@NgModule({
  declarations: [
    AppComponent,
    ListaLibrosComponent,
    ListaAutoresComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,   
    ToastModule,
    TableModule 
  ],
  providers: [AutorService,LibroService,LoginService,UsuarioService],
  bootstrap: [AppComponent]
})
export class AppModule { }
