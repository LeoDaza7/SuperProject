import { Store } from "./store";

export class ProductCart {
    productCode: string;
    shippingDeliveryType: number;
    store: Store;
    quantity: number;
}