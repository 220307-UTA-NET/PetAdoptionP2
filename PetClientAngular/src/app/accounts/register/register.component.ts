import { Component, OnInit } from '@angular/core';

import { Account } from '../../account';
import { AccountService } from '../../account.service';
import { TokenService } from '../../token.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  form: Account = {
    accountId: 0,
    userName: 'your username',
    password: '111111',
    firstName: 'your first name',
    lastName: 'your last name',
    email: 'default@email.com',
    phone: '1111111111',
    address: '3994 Clairemont Mesa Blvd Unit A, San Diego, CA 92117',
    city: 'San Diego',
    state: 'CA',
    zip: '92117',
    country: 'USA'
  }
  isLoginFailed: boolean = false;
  isLoggedIn = false;
  errorMessage = '';
  roles: string[] = [];

  constructor(private accountService: AccountService, private tokenService: TokenService) { }

  ngOnInit(): void {
  }
  
  onSubmit(): void {
    //const { username, password } = this.form;
    this.accountService.addAccount(this.form).subscribe({
      next: data => {
        this.tokenService.saveToken(data.accessToken);
        this.tokenService.saveUser(data);
        this.isLoginFailed = false;
        this.isLoggedIn = true;
        this.roles = this.tokenService.getUser().roles;
        this.reloadPage();
      },
      error: err => {
        this.errorMessage = err.error.message;
        this.isLoginFailed = true;
      }
    });
  }
  reloadPage(): void {
    window.location.reload();
  }
}
