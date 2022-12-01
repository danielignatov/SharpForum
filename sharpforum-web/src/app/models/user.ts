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
}

export interface UserFormValues {
    displayName: string;
    password: string;
}