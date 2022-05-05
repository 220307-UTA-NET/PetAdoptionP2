import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

import { Observable, of, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { MessageService } from './message.service';
import { Account } from './account';
import { ACCOUNTS } from './mock-accounts';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private accountsUrl = 'https://petadoptionp2.azurewebsites.net/Account';
  private loginUrl = 'https://petadoptionp2.azurewebsites.net/Login';
  //private accountsUrl = 'https://localhost:7012/Account';
  //private loginUrl = 'https://localhost:7012/Login';
  constructor(
    private http: HttpClient,
    private messageService: MessageService
    ) { }
   getAccounts(): Observable<Account[]> {
     return this.http.get<Account[]>(this.accountsUrl).pipe(tap(_ => this.log('fetched accounts')), catchError(this.handleError<Account[]>('getAccounts', [])));
   }
 
  getAccount(id: number): Observable<Account|undefined> {
    
    this.log(`AccountService: fetched Account id=${id}`);
    return this.http.get<Account>(`${this.accountsUrl}/${id}`).pipe(tap(_ => this.log(`fetched Account id=${id}`)), catchError(this.handleError<Account>(`getAccount id=${id}`)));
  }
  
  private log(message: string): void {
    this.messageService.add('AccountService: ' + message);
  }
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      this.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }
  login(username: string, password: string): Observable<any> {
    
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
    return this.http.post(this.loginUrl, {
      "accountId": 0,
      "userName": username,
      "firstName": "string",
      "lastName": "string",
      "password": password,
      "email": "string",
      "phone": "string",
      "address": "string",
      "city": "string",
      "state": "string",
      "zip": "string",
      "country": "string"
    }, httpOptions);
  }

  addAccount(account: Account): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
    return this.http.post(this.accountsUrl, account, httpOptions);
  }
  updateAccount(id:number, account: Account) {
    return this.http.put(`${this.accountsUrl}/${id}`, account);
  }
  deleteAccount(id: number) {
    return this.http.delete(`${this.accountsUrl}/${id}`);
  }
}
