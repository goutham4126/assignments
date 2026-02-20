import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProductService } from '../../services/product';
import { OrderService } from '../../services/order';

@Component({
  selector: 'app-customer',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './customer.html',
  styleUrl: './customer.css',
})
export class Customer implements OnInit {

  productService = inject(ProductService);
  orderService = inject(OrderService);

  products = this.productService.products;
  orders = this.orderService.orders;

  quantityMap = signal<{ [key: number]: number }>({});

  ngOnInit(): void {
    this.productService.loadProducts();
    this.orderService.loadMyOrders();
  }

  setQuantity(productId: number, value: number) {
    this.quantityMap.update(q => ({
      ...q,
      [productId]: +value
    }));
  }

  placeOrder(productId: number) {
    const quantity = this.quantityMap()[productId] || 1;
    this.orderService.createOrder(productId, quantity);
  }

  viewOrder(id: number) {
    this.orderService.getOrderById(id);
  }
}