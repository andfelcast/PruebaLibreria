import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListaAutoresComponent } from './components/lista-autores/lista-autores.component';
import { ListaLibrosComponent } from './components/lista-libros/lista-libros.component';
import { LoginComponent } from './components/login/login.component';

const routes: Routes = [
  { path: 'Autores', component: ListaAutoresComponent },
  { path: 'Libros', component: ListaLibrosComponent },
  { path: 'InicioSesion', component: LoginComponent },  
  { path: '',   redirectTo: '/Libros', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
