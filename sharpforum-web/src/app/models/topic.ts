import { Category } from "./category";
import { User } from "./user";

export interface Topic {
    id: string;
    subject: string;
    message: string;
    sticky: boolean;
    locked: boolean;
    authorId: string;
    author: User;
    categoryId: string;
    category: Category;
    createdOn: Date | null;
}