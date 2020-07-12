import { Category } from './category.model';

export class Product {
    id: number;
    name: string;
    categories: Category[];
}