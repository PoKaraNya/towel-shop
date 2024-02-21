import {Component, OnInit} from '@angular/core';
import {Category} from "../shared/models/category";
import {ShopService} from "../shop/shop.service";
import {ShopParams} from "../shared/models/shopParams";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {

  categories: Category[] = [];

  constructor(private shopService: ShopService) {
  }

  ngOnInit(): void {
    // this.getCategoriesForHome();
  }

  // getCategoriesForHome() {
  //   this.shopService.getCategoriesForHome().subscribe({
  //     next: response =>
  //       {
  //         this.categories = response.data;
  //       },
  //     error: error => console.log(error)
  //   })
  // }

}
