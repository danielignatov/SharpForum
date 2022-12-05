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

export interface LoginUserFormValues {
    displayName: string;
    password: string;
}

export interface RegisterUserFormValues {
    displayName: string;
    password: string;
    email: string;
}

export interface RegisterUserResult {
    success: boolean;
    errors: string[];
}

export class RegisterUserResult implements RegisterUserResult {
    constructor(success: boolean, errors: string[]) {
        this.success = success;
        this.errors = errors;
    }
}