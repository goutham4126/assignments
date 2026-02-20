import { Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ProductService {

  private apiUrl = 'https://localhost:7031/api/product';

  products = signal<any[]>([]);
  selectedProduct = signal<any | null>(null);

  constructor(private http: HttpClient) {}

  loadProducts() {
    this.http.get<any[]>(this.apiUrl)
      .subscribe(res => this.products.set(res));
  }

  getProductById(id: number) {
    this.http.get<any>(`${this.apiUrl}/${id}`)
      .subscribe(res => this.selectedProduct.set(res));
  }

  createProduct(product: any) {
    this.http.post(this.apiUrl, product)
      .subscribe(() => this.loadProducts());
  }

  updateProduct(id: number, product: any) {
    this.http.put(`${this.apiUrl}/${id}`, product)
      .subscribe(() => this.loadProducts());
  }

  deleteProduct(id: number) {
    this.http.delete(`${this.apiUrl}/${id}`)
      .subscribe(() => this.loadProducts());
  }
}