export interface Role {
    id: string;
    name: string;
}

export class Role implements Role {
    constructor() {
        this.id = 'unknown';
        this.name = 'unknown';
    }
}