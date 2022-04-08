import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Autor } from '../entities/autor';

@Injectable({
  providedIn: 'root'
})
export class AutorService {
  apiHost: string = 'https://localhost:44319/api/Autor'
  
  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  Listar():Observable<Autor[]>{               
    return this.http.get<Autor[]>(this.apiHost + '/Listar')
    .pipe(
      catchError(this.handleError('ListarAutor',[]))
    );    
  }

  ObtenerDetalle(id:string) : Observable<Autor>{
    return this.http.get<Autor>(this.apiHost + '/' + id)
    .pipe(      
      catchError(this.handleError('DetalleAutor',null))
    );     
  }

  Buscar(nombre:string) : Observable<Autor[]>{
    return this.http.get<Autor[]>(this.apiHost + '/?termino=' + nombre)
    .pipe(      
      catchError(this.handleError('BuscarAutor',null))
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
