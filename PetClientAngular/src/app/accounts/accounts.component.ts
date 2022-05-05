import { Component, OnInit } from '@angular/core';

import { Account } from '../account';
import { ACCOUNTS } from '../mock-accounts';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-accounts',
  templateUrl: './accounts.component.html',
  styleUrls: ['./accounts.component.css']
})
export class AccountsComponent implements OnInit {
  accounts: Account[] = [];
  accountLoggedIn: Account = {"accountId":0, "userName":"", "password":"", "firstName":"", "lastName":"", "email":"", "phone":"", "address":"", "city":"", "state":"", "zip":"", "country":""}
  ;
  
  constructor(
    private accountService: AccountService, 
  
    ) { }

  
  ngOnInit(): void {
    this.getAccounts();
  }
  getAccounts(): void {
    this.accountService.getAccounts().subscribe(accounts => this.accounts = accounts);
  }

}