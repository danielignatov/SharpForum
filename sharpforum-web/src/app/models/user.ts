import { Role } from "./role";

export interface User {
    id: string;
    about: string;
    avatar: string;
    displayName: string;
    email: string;
    roleId: string;
    role: Role;
    signature: string;
    location: string;
    website: string;
    createdOn: Date | null;
}

export class User implements User {
    constructor() {
        this.id = 'unknown';
        this.about = '';
        this.avatar = '';
        this.displayName = 'unknown';
        this.email = 'unknown@example.com';
        this.roleId = 'unknown';
        this.role = new Role();
        this.signature = '';
        this.location = '';
        this.website = '';
        this.createdOn = null;
    }
}

export interface LoginUserFormValues {
    displayName: string;
    password: string;
}

export interface RegisterUserFormValues {
    displayName: string;
    password: string;
    email: string;
}