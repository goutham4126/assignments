import { Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class OrderService {

  private apiUrl = 'https://localhost:7055/api/Order';

  orders = signal<any[]>([]);
  allOrders = signal<any[]>([]);
  selectedOrder = signal<any | null>(null);

  constructor(private http: HttpClient) {}

  createOrder(productId: number, quantity: number) {
    this.http.post(this.apiUrl, { productId, quantity })
      .subscribe(() => this.loadMyOrders());
  }

  loadMyOrders() {
    this.http.get<any[]>("https://localhost:7055/api/Order/my-orders")
      .subscribe(res => this.orders.set(res));
  }

  loadAllOrders() {
    this.http.get<any[]>('https://localhost:7055/api/Order/all')
      .subscribe(res => this.allOrders.set(res));
  }

  getOrderById(id: number) {
    this.http.get<any>(`${this.apiUrl}/${id}`)
      .subscribe(res => this.selectedOrder.set(res));
  }
}