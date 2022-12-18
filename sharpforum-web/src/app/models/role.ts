export interface Role {
    id: string;
    name: string;
}

export class Role implements Role {
    constructor() {
        Object.assign(this);
    }
}