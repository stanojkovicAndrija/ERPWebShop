import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';
import { AdminGuard } from './core/guards/admin.guard';

const routes: Routes = [
  {path: 'shop', loadChildren: () => import('./shop/shop.module').then(m => m.ShopModule)},
  {path: 'basket', loadChildren: () => import('./basket/basket.module').then(m => m.BasketModule)},
  {
    path: 'checkout', 
    canActivate: [AuthGuard],
    loadChildren: () => import('./checkout/checkout.module').then(m => m.CheckoutModule)
  },
  {
    path: 'orders', 
    canActivate: [AuthGuard],
    loadChildren: () => import('./orders/orders.module').then(m => m.OrdersModule)
  },
  {
    path: 'admin',
    canActivate:[AuthGuard,AdminGuard],
    loadChildren:()=> import('./admin/admin.module')
    .then(mod=>mod.AdminModule), data: {breadcrumb: 'Admin'}
  },
  {path: 'account', loadChildren: () => import('./account/account.module').then(m => m.AccountModule)},
  {path: '**', redirectTo: '/shop', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
