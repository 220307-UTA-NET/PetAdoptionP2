import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { MessageService } from './message.service';
import { Pet } from './pet';
import { PETS } from './mock-pets';

@Injectable({
  providedIn: 'root'
})
export class PetService {
  private petsUrl = 'https://petadoptionp2.azurewebsites.net/Pet';
  //private petsUrl = 'https://localhost:7012/Pet';
  constructor(
    private http: HttpClient,
    private messageService: MessageService
    ) { }
   getPets(): Observable<Pet[]> {
     return this.http.get<Pet[]>(this.petsUrl).pipe(tap(_ => this.log('fetched pets')), catchError(this.handleError<Pet[]>('getPets', [])));
   }
 
  getPet(id: number): Observable<Pet|undefined> {
    //const pet = PETS.find(p => p.petId === id);
    this.log(`PetService: fetched pet id=${id}`);
    //this.log(this.http.get<Pet>(`${this.petsUrl}/${id}`));
    return this.http.get<Pet>(`${this.petsUrl}/${id}`).pipe(tap(_ => this.log(`fetched pet id=${id}`)), catchError(this.handleError<Pet>(`getPet id=${id}`)));
  }
  private log(message: string): void {
    this.messageService.add('PetService: ' + message);
  }
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      this.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }
}
