export interface Result {
    success: boolean;
    errors: string[];
}

export class Result implements Result {
    constructor(success: boolean, errors: string[]) {
        this.success = success;
        this.errors = errors;
    }
}