import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from "@angular/common/http";
import {CategoryData, Pagination} from "../shared/models/pagination";
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
    if(shopParams.search) params = params.append('search', shopParams.search);

    return this.http.get<Pagination<Product[]>>(this.baseUrl + 'products', {params})
  }

  getCategoriesForHome() {
    let params = new HttpParams();
    return this.http.get<CategoryData<Category[]>>(this.baseUrl + 'category', {params})
  }

  getProduct(id: number){
    return this.http.get<Product>(this.baseUrl + 'products/' + id)
  }

  getCategories() {
    return this.http.get<Category[]>(this.baseUrl + 'products/categories')
  }

}
