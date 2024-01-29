import {Component, OnInit} from '@angular/core';
import {Product} from "../shared/models/product";
import {ShopService} from "./shop.service";
import {Category} from "../shared/models/category";
import {ShopParams} from "../shared/models/shopParams";

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss'
})
export class ShopComponent implements OnInit {
  products: Product[] = [];
  categories: Category[] = [];
  shopParams = new ShopParams();
  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price: Low to high', value: 'priceAsc'},
    {name: 'Price: High to low', value: 'priceDesc'},
  ];
  totalCount = 0;

  constructor(private shopService: ShopService) {
  }

  ngOnInit(): void {
    this.getProducts();
    this.getCategories();
  }

  getProducts() {
    this.shopService.getProducts(this.shopParams).subscribe({
      next: response => {
        this.products = response.data;
        this.shopParams.pageNumber = response.pageIndex;
        this.shopParams.pageSize = response.pageSize;
        this.totalCount = response.pageCount;
      },
      error: error => console.log(error)
    })
  }

  getCategories() {
    this.shopService.getCategories().subscribe({
      next: response => this.categories = [
        {
          id: 0,
          title: 'All',
          description: 'All',
          pictureUrl: 'All',
          createdAt: new Date(),
          updatedAt: new Date()
        },
        ...response
      ],
      error: error => console.log(error)
    })
  }

  onCategorySelected(categoryId: number) {
    this.shopParams.categoryId = categoryId;
    this.getProducts();
  }

  onSortSelected(event: any) {
    this.shopParams.sort = event.target.value;
    this.getProducts();
  }

  onPageChanged(event: any) {
    if (this.shopParams.pageNumber !== event){
      this.shopParams.pageNumber = event;
      this.getProducts();
    }

  }
}
