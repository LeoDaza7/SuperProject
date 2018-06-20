import { Category } from "./category";

export class Product {
    code: string;
    name: string;
    price: number;
    description: string;
    imageURL: string;
    type: number;
    shippingDeliveryType: number;
    category: Category;
  }
  