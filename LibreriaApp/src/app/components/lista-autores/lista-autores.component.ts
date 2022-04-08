import { Component, OnInit } from '@angular/core';
import { Autor } from 'src/app/entities/autor';
import { Router } from '@angular/router';
import { AutorService } from 'src/app/services/autor.service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-lista-autores',
  templateUrl: './lista-autores.component.html',
  styleUrls: ['./lista-autores.component.css'],
  providers: [MessageService]
})
export class ListaAutoresComponent implements OnInit {

  lstAutores: Autor[];
  valido: boolean = false;

  constructor(private autorService : AutorService,
    private mensajeService:MessageService,
    private router: Router) { }

  ngOnInit(): void {
    this.Listado();
    
  }

  Listado(): void {    
    this.autorService.Listar().subscribe((data:Autor[]) => {
      this.lstAutores = data;        
      if(this.lstAutores.length > 0){
        this.mensajeService.add({key: 'bc', severity:'success', summary: 'Información de carga', detail: 'La carga de autores fue exitosa'});        
      }
      else{
        this.mensajeService.add({key: 'bc', severity:'error', summary: 'Información de carga', detail: 'Error em la carga de autores'});
        alert('No Funcionó')
      }            
    }             
    );        
  }

  Crear():void{    
    this.router.navigate(['/CreaDoctor']);
  }

  Detalle(id:number){
    this.router.navigate(['/Autor',id]);

  }

}
