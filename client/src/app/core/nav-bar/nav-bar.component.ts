import { Component } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { AccountService } from 'src/app/account/account.service';
import { BasketService } from 'src/app/basket/basket.service';
import { Basket, BasketItem } from 'src/app/shared/models/basket';
import { User } from 'src/app/shared/models/user';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent   {

  basket$: Observable<Basket | null>;
  currentUser$: Observable<User | null>;
  isAdmin$: Observable<boolean>;
  constructor(public basketService: BasketService, public accountService: AccountService) {
    this.isAdmin$ = new Observable<boolean>(); 
    this.basket$ = new Observable<Basket>();
    this.currentUser$ = new Observable<User>;
  }

  ngOnInit(){
    this.basket$ = this.basketService.basketSource$;
    this.currentUser$ = this.accountService.currentUser$;
    this.isAdmin$ = this.accountService.isAdmin$;
  }
  getCount(items: BasketItem[]) {
    return items.reduce((sum, item) => sum + item.quantity, 0);
  }

}
