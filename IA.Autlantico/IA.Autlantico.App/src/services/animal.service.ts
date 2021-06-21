import { Hosting } from './../models/hosting.model';
import { Animal } from './../models/animal.model';
import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import {catchError, map} from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class AnimalService implements HttpInterceptor{

  private url: string = 'https://localhost:44382/api/autlantico';
  private animalsList: any[];

constructor(private httpClient: HttpClient) {
    this.animalsList = [];
 }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    throw new Error('Method not implemented.');
  }

  save(animal: Animal): Observable<Animal> {
    return this.httpClient.post<Animal>(this.url, animal).pipe(
      catchError((error) => {
        console.log('error is intercept')
        console.error(error);
        return throwError(error.message);
      }))
  }

  getAll(): Observable<Animal[]> {
    return this.httpClient.get<Animal[]>(this.url).pipe(
      catchError((error) => {
        console.log('error is intercept')
        console.error(error);
        return throwError(error.message);
      }))
    }

  getByName(namePet: string): Observable<Animal[]> {
    return this.httpClient.get<Animal[]>(this.url+'/'+namePet).pipe(
      catchError((error) => {
        console.log('error is intercept')
        console.error(error);
        return throwError(error.message);
      }))
    }

    getAllHosting(): Observable<Hosting[]> {
      return this.httpClient.get<Hosting[]>(this.url).pipe(
        catchError((error) => {
          console.log('error is intercept')
          console.error(error);
          return throwError(error.message);
        }))
      }
}
