import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from "@angular/common/http";
import {Pagination} from "../shared/models/pagination";
import {Product} from "../shared/models/product";
import {Category} from "../shared/models/category";

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/'

  constructor(private http: HttpClient) {
  }

  getProducts(categoryId?: number, sort?: string) {
    let params = new HttpParams();

    if (categoryId) params = params.append('CategoryId', categoryId);
    if (sort) params = params.append('sort', sort);

    return this.http.get<Pagination<Product[]>>(this.baseUrl + 'products', {params})
  }

  getCategories() {
    return this.http.get<Category[]>(this.baseUrl + 'products/categories')
  }

}
