import { Injectable } from '@angular/core';
const TOKEN_KEY = 'auth-token';
const USER_KEY = 'userName';
const TOKEN_PET = 'current-pet';
const PET_KEY = 'pet-name';
@Injectable({
  providedIn: 'root'
})
export class TokenService {

  constructor() { }
  signOut(): void {
    window.sessionStorage.clear();
  }
  
  public saveToken(token: string): void {
    window.sessionStorage.removeItem(TOKEN_KEY);
    window.sessionStorage.setItem(TOKEN_KEY, token);
  }
  public getToken(): string | null {
    return window.sessionStorage.getItem(TOKEN_KEY);
  }
  public saveUser(user: any): void {
    window.sessionStorage.removeItem(USER_KEY);
    window.sessionStorage.setItem(USER_KEY, JSON.stringify(user));
  }
  public getUser(): any {
    const user = window.sessionStorage.getItem(USER_KEY);
    if (user) {
      return JSON.parse(user);
    }
    return {};
  }

  public savePetToken(token: string): void {
    window.sessionStorage.removeItem(TOKEN_PET);
    window.sessionStorage.setItem(TOKEN_PET, token);
  }
  public getPetToken(): string | null {
    return window.sessionStorage.getItem(TOKEN_PET);
  }
  public savePetUser(pet: any): void {
    window.sessionStorage.removeItem(PET_KEY);
    window.sessionStorage.setItem(PET_KEY, JSON.stringify(pet));
  }
  public getPet(): any {
    const pet = window.sessionStorage.getItem(PET_KEY);
    if (pet) {
      return JSON.parse(pet);
    }
    return {};
  }
}
