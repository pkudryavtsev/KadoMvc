import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IProduct } from '../models/product';
import { IProductBrand } from '../models/productBrand';
import { IProductCategory } from '../models/productCategory';
import { IProductType } from '../models/productType';
import { ShopParams } from '../models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class TestService {
  baseUrl = 'https://localhost:5001/'

  constructor(private http: HttpClient) { }

  getProducts(shopParams: ShopParams): Observable<IProduct[]> {
    let params = new HttpParams();

    if (shopParams.brandId !== 0){
      params = params.append('brandId', shopParams.brandId.toString());
    }

    if (shopParams.typeId !== 0){
      params = params.append('typeId', shopParams.typeId.toString());
    }

    if (shopParams.search) {
      params = params.append('search', shopParams.search);
    }

    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());

    return this.http.get<IProduct[]>(`${this.baseUrl}products`, {params});
  }
  getBoxes(): Observable<IProductBrand[]> {
    return this.http.get<IProductBrand[]>(`${this.baseUrl}boxes`);
  }
  getProductBrands(): Observable<IProductBrand[]> {
    return this.http.get<IProductBrand[]>(`${this.baseUrl}productBrands`);
  }
  getProductTypes(): Observable<IProductType[]> {
    return this.http.get<IProductType[]>(`${this.baseUrl}productTypes`);
  }
  getProductCategories(): Observable<IProductCategory[]> {
    return this.http.get<IProductCategory[]>(`${this.baseUrl}productCategories`);
  }

}
