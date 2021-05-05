import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IProduct } from '../models/product';
import { IProductBrand } from '../models/productBrand';
import { IProductCategory } from '../models/productCategory';
import { IProductType } from '../models/productType';
import { ShopParams } from '../models/shopParams';
import { TestService } from './test.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {
  @ViewChild('search', { static : false }) searchTerm: ElementRef;
  products: IProduct[];
  productsWithParams: IProduct[];
  boxes: any[];
  paramsProductBrands: IProductBrand[];
  paramsProductTypes: IProductType[];
  paramsProductCategories: IProductCategory[];
  productBrands: IProductBrand[];
  productTypes: IProductType[];
  productCategories: IProductCategory[];

  shopParams = new ShopParams();

  constructor(private testService: TestService) { }

  ngOnInit(): void {
    this.getParamsProductBrands();
    this.getParamsProductTypes();
    this.getParamsProductCategories();
  }

  getProducts(): void {
    this.testService.getProducts(this.shopParams).subscribe(response => {
      this.products = response;
    }, error => {
      console.log(error);
    })
  }

  getProductsWithParams(): void {
    this.testService.getProducts(this.shopParams).subscribe(response => {
      this.productsWithParams = response;
      this.shopParams = new ShopParams();
    }, error => {
      console.log(error);
    })
  }

  getBoxes(): void {

  }


  getProductBrands(): void {
    this.testService.getProductBrands().subscribe(response => {
      this.productBrands = response;
    }, error => {
      console.log(error);
    })
  }

  
  getProductTypes(): void {
    this.testService.getProductTypes().subscribe(response => {
      this.productTypes = response;
    }, error => {
      console.log(error);
    })
  }

  getProductCategories(): void {
    this.testService.getProductCategories().subscribe(response => {
      this.productCategories = response;
    }, error => {
      console.log(error);
    })
  }

  getParamsProductBrands(): void {
    this.testService.getProductBrands().subscribe(response => {
      this.paramsProductBrands = response;
    }, error => {
      console.log(error);
    })
  }


  getParamsProductTypes(): void {
    this.testService.getProductTypes().subscribe(response => {
      this.paramsProductTypes = response;
    }, error => {
      console.log(error);
    })
  }

  getParamsProductCategories(): void {
    this.testService.getProductCategories().subscribe(response => {
      this.paramsProductCategories = response;
    }, error => {
      console.log(error);
    })
  }

  onBrandSelected(brandId: number): void {
    this.shopParams.brandId = brandId;
    console.log(this.shopParams);
  }

  onTypeSelected(typeId: number): void {
    this.shopParams.typeId = typeId;
    console.log(this.shopParams);
  }

  onCategorySelected(categoryId: number): void {
    this.shopParams.categoryId = categoryId;
    console.log(this.shopParams);
  }

  onSearch(): void {
    this.shopParams.search = this.searchTerm.nativeElement.value;
    console.log(this.shopParams);
  }

}
