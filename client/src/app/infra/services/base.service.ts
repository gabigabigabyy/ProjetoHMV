import { Usuario } from './../models/usuario';
import { environment } from './../../../environments/environment';
import { Injectable } from '@angular/core';
import { MatSnackBar } from "@angular/material/snack-bar";
import { HttpClient } from "@angular/common/http";
import { Observable, EMPTY } from "rxjs";
import { map, catchError } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  urlBase = environment.url;
  urlToken = environment.url + '/token';
  token: string;
  _usuario: Usuario;

  constructor(private snackBar: MatSnackBar, private http: HttpClient) { }

  // public header(): Headers {
  //   let _headers = new Headers();
  //   _headers.append('Content-Type', 'application/json;charset=utf8');
  //   _headers.append('Authorization', 'Bearer ' + this.token);
  //   /*_headers.append('Cache-control', 'no-cache');
  //   _headers.append('Cache-control', 'no-store');
  //   _headers.append('Expires', '0');
  //   _headers.append('Pragma', 'no-cache');
  //   _headers.append('timestamp', (new Date()).getTime().toString());*/
  //   return _headers;
  // }

  public get<T>(url: string): Observable<T> {
    return this.http.get<T>(this.urlBase + url).pipe(
      map((obj) => obj)
      //catchError((e) => this.errorHandler(e))
    );
  }

  errorHandler(erro: string): Observable<string> {
    this.showMessage(erro, true);
    return EMPTY;
  }

  showMessage(msg: string, isError: boolean = false): void {
    this.snackBar.open(msg, "X", {
      duration: 6000,
      horizontalPosition: "center",
      verticalPosition: "top",
      panelClass: isError ? ["msg-error"] : ["msg-success"],
    });
  }
}
