import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from "@angular/common/http";
import {Pagination} from "../shared/models/pagination";
import {Product} from "../shared/models/product";
import {Category} from "../shared/models/category";
import {ShopParams} from "../shared/models/shopParams";

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/'

  constructor(private http: HttpClient) {
  }

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();

    if (shopParams.categoryId > 0) params = params.append('CategoryId', shopParams.categoryId);
    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber);
    params = params.append('pageSize', shopParams.pageSize);

    return this.http.get<Pagination<Product[]>>(this.baseUrl + 'products', {params})
  }

  getCategories() {
    return this.http.get<Category[]>(this.baseUrl + 'products/categories')
  }

}
