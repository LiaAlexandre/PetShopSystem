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
  private url2: string = 'https://localhost:44382/api/autlantico/GetHostings';
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
      return this.httpClient.get<Hosting[]>(this.url2).pipe(
        catchError((error) => {
          console.log('error is intercept')
          console.error(error);
          return throwError(error.message);
        }))
      }

      deleteAnimal(animalId: number): Observable<any> {
        const apiUrl = `${this.url}/${animalId}`;
        return this.httpClient.delete<number>(apiUrl);
      }

      updateAnimal(animal: Animal): Observable<Animal> {
        console.log(animal);
        return this.httpClient.put<Animal>(this.url, animal).pipe(
          catchError((error) => {
            console.log('error is intercept')
            console.error(error);
            return throwError(error.message);
          }))
      }

      getAnimal(animalId: number): Observable<Animal> {
        console.log(animalId);
        return this.httpClient.get<Animal>(this.url+'/GetAnimal/'+animalId).pipe(
          catchError((error) => {
            console.log('error is intercept')
            console.error(error);
            return throwError(error.message);
          }))
      }
}
