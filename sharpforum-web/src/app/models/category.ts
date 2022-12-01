export interface Category {
    id: string;
    name: string;
    description: string;
    displayOrder: number;
    isPlaceholder: boolean;
}

export class Category implements Category {
    constructor() {
        Object.assign(this);
    }
}