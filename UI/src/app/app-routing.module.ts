import { NgModule } from '@angular/core';
import {Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { LogInComponent } from './log-in/log-in.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { ShippingOptionsComponent } from './shipping-options/shipping-options.component';

const routes: Routes = [
    {path: '', redirectTo: '/home', pathMatch: 'full'},
    {path: 'home', component: HomeComponent},
    {path: 'log-in', component: LogInComponent},
    {path: 'sign-in', component: SignInComponent},
    {path: 'product-list', component: ProductListComponent},
    {path: 'product-detail', component: ProductDetailComponent},
    {path: 'shopping-cart', component: ShoppingCartComponent},
    {path: 'shipping-options', component: HomeComponent},
    {path: '**', component: ShippingOptionsComponent}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule {}
export const RoutingComponents = [
    HomeComponent,
    PageNotFoundComponent,
    LogInComponent,
    SignInComponent,
    ProductListComponent,
    ProductDetailComponent,
    ShoppingCartComponent,
    ShippingOptionsComponent
]
