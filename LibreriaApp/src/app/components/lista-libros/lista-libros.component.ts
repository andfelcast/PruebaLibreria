import { Component, OnInit } from '@angular/core';
import { Libro } from 'src/app/entities/libro';
import { LibroService } from 'src/app/services/libro.service';
import { MessageService } from 'primeng/api';
import { Router } from '@angular/router';
import * as XLSX from 'xlsx';

@Component({
  selector: 'app-lista-libros',
  templateUrl: './lista-libros.component.html',
  styleUrls: ['./lista-libros.component.css'],
  providers: [MessageService]
})
export class ListaLibrosComponent implements OnInit {

  lstLibros: Libro[];
  valido: boolean = false;
  public autor:string="";
  public inicio:string="";
  public fin:string="";
  private nombreArchivo= 'ReporteLibros.xlsx';

  constructor(private LibroService : LibroService,
    private mensajeService:MessageService,
    private router: Router) { }

  ngOnInit(): void {
    this.Listado();    
  }

  Listado(): void {    
    this.LibroService.Listar().subscribe((data:Libro[]) => {
      this.lstLibros = data;
      if(this.lstLibros.length > 0){
        this.mensajeService.add({key: 'bc', severity:'success', summary: 'Información de carga', detail: 'La carga de libros fue exitosa'});
      }
      else{
        this.mensajeService.add({key: 'bc', severity:'error', summary: 'Información de carga', detail: 'Error em la carga de libros'});
      }
    }             
    );        
  }

  GenerarExcel():void{        
    let tabla = document.getElementById('tblLibros');
    const ws: XLSX.WorkSheet =XLSX.utils.table_to_sheet(tabla);
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Hoja1');    
    XLSX.writeFile(wb, this.nombreArchivo);
    this.mensajeService.add({key: 'bc', severity:'success', summary: 'Exportar a Excel', detail: 'Archivo generado exitosamente'});
  }

  Busqueda():void{        
    this.LibroService.Buscar(this.autor,this.inicio,this.fin).subscribe((data:Libro[]) => {
      this.lstLibros = data;
      if(this.lstLibros.length > 0){
        this.mensajeService.add({key: 'bc', severity:'success', summary: 'Información de carga', detail: 'La carga de libros fue exitosa'});
      }
      else{
        this.mensajeService.add({key: 'bc', severity:'error', summary: 'Información de carga', detail: 'Error em la carga de libros'});
      }
    }             
    );  
  }
  Limpiar():void{    
    this.autor = "";
    this.inicio = "";
    this.fin = "";
    this.Listado();
  }

  
}
