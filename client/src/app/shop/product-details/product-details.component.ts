import {Component, OnInit} from '@angular/core';
import {Product} from "../../shared/models/product";
import {ShopService} from "../shop.service";
import {ActivatedRoute} from "@angular/router";
import {error} from "@angular/compiler-cli/src/transformers/util";
import {BasketService} from "../../basket/basket.service";
import {take} from "rxjs";

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.scss'
})
export class ProductDetailsComponent implements OnInit {
  product?: Product;
  quantity = 1;
  quantityInBasket = 0;

  constructor(private shopService: ShopService, private activatedRoute: ActivatedRoute,
              private basketService: BasketService) {
  }

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (id) this.shopService.getProduct(+id).subscribe({
      next: product => {
        this.product = product;
        this.basketService.basketSource$.pipe(take(1)).subscribe({
          next: basket => {
            const item = basket?.items.find(x => x.id === +id);
            if (item) {
              this.quantity = item.quantity;
              this.quantityInBasket = item.quantity;
            }
          }
        })
      },
      error: error => console.log(error)
    });
  }

  incrementQuantity() {
    this.quantity++;
  }

  decrementQuantity() {
    this.quantity--;
  }

  updateBasket() {
    if (this.product) {
      if (this.quantity > this.quantityInBasket) {
        const itemToAdd = this.quantity - this.quantityInBasket;
        this.quantityInBasket += itemToAdd;
        this.basketService.addItemToBasket(this.product, itemToAdd);
      } else {
        const itemToRemove = this.quantityInBasket - this.quantity;
        this.quantityInBasket -= itemToRemove;
        this.basketService.removeItemFromBasket(this.product.id, itemToRemove);
      }
    }
  }

  get buttonText() {
    return this.quantityInBasket === 0 ? 'Add to basket' : 'Update basket'
  }
}
