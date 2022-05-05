import { Component, OnInit } from '@angular/core';
import { Account } from '../../account';
import { AccountService } from '../../account.service';
import { TokenService } from '../../token.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form: any = {
    username: null,
    password: null
  };
  isLoggedIn = false;
  isLoginFailed = false;
  errorMessage = '';
  roles: string[] = [];
  constructor(private accountService: AccountService, private tokenService: TokenService) { }
  ngOnInit(): void {
    if (this.tokenService.getToken()) {
      this.isLoggedIn = true;
      this.roles = this.tokenService.getUser().roles;
    }
  }
  onSubmit(): void {
    const { username, password } = this.form;
    this.accountService.login(username, password).subscribe({
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
