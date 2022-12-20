export interface Category {
    id: string;
    name: string;
    description: string;
    displayOrder: number;
    isPlaceholder: boolean;
    topicCount: number;
    replyCount: number;
}

export class Category implements Category {
    constructor() {
        Object.assign(this);
    }
}

export interface AddCategoryFormValues {
    name: string;
    description: string;
    displayOrder: number;
    isPlaceholder: boolean;
}