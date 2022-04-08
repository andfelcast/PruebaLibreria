import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Libro } from '../entities/libro';
import { BusquedaLibro } from '../entities/busqueda-libro';
import { FindValueOperator } from 'rxjs/internal/operators/find';

@Injectable({
  providedIn: 'root'
})
export class LibroService {
  apiHost: string = 'https://localhost:44319/api/Libro'
  
  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  Listar():Observable<Libro[]>{               
    return this.http.get<Libro[]>(this.apiHost + '/Listar')
    .pipe(
      catchError(this.handleError('ListarLibro',[]))
    );    
  }

  ObtenerDetalle(id:string) : Observable<Libro>{
    return this.http.get<Libro>(this.apiHost + '/' + id)
    .pipe(      
      catchError(this.handleError('DetalleLibro',null))
    );     
  }

  Buscar(nombre:string,inicio:string,fin:string) : Observable<Libro[]>{
    if(inicio == "")
      inicio="0";
    if(Number(fin)==0 || fin == "")
      fin = "9999";
    return this.http.get<Libro[]>(this.apiHost + '/Busqueda?NombreLibro=' + nombre +'&AnioInicio=' + inicio + '&AnioFin=' + fin)
    .pipe(      
      catchError(this.handleError('BuscarLibro',null))
    );     
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
   
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
   
      // TODO: better job of transforming error for user consumption
      //this.log(`${operation} failed: ${error.message}`);
   
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}