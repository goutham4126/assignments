import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProductService } from '../../services/product';
import { OrderService } from '../../services/order';

@Component({
  selector: 'app-manager',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './manager.html',
  styleUrl: './manager.css',
})
export class Manager implements OnInit {

  productService = inject(ProductService);
  orderService = inject(OrderService);

  products = this.productService.products;
  allOrders = this.orderService.allOrders;
  selectedProduct = this.productService.selectedProduct;

  isEditing = signal(false);

  formProduct = signal<any>({
    name: '',
    description: '',
    category: '',
    price: 0
  });

  ngOnInit(): void {
    this.productService.loadProducts();
    this.orderService.loadAllOrders(); 
  }

  // CREATE
  createProduct() {
    this.productService.createProduct(this.formProduct());
    this.resetForm();
  }

  // EDIT MODE
  editProduct(product: any) {
    this.formProduct.set({ ...product });
    this.isEditing.set(true);
  }

  // UPDATE
  updateProduct() {
    const product = this.formProduct();
    if (!product.id) return;

    this.productService.updateProduct(product.id, product);
    this.resetForm();
  }

  // DELETE
  deleteProduct(id: number) {
    this.productService.deleteProduct(id);
  }

  // GET BY ID
  viewProduct(id: number) {
    this.productService.getProductById(id);
  }

  resetForm() {
    this.formProduct.set({
      name: '',
      description: '',
      category: '',
      price: 0
    });
    this.isEditing.set(false);
  }
}