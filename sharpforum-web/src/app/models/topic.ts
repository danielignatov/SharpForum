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
    createdOn: Date;
    replyCount: number;
}

export class Topic implements Topic {
    constructor() {
        this.id = 'unknown';
        this.subject = 'unknown';
        this.message = 'unknown';
        this.sticky = false;
        this.locked = false;
        this.authorId = 'unknown';
        this.author = new User();
        this.categoryId = 'unknown';
        this.category = new Category();
        this.createdOn = new Date();
        this.replyCount = 0;
    }
}

export interface AddTopicFormValues {
    authorId: string;
    categoryId: string;
    subject: string;
    message: string;
    sticky: boolean;
    locked: boolean;
}