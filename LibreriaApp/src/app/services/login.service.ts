import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { UsuarioLogin } from '../entities/usuario-login';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  apiHost: string = 'https://localhost:44394/'
  apiService: string = 'api/Usuario/Login';
  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  Login(objLogin: UsuarioLogin): Observable<boolean>{
    return this.http.post(this.apiHost + this.apiService,objLogin)
    .pipe(      
      catchError(this.handleError('Login',null))
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
