export interface Topic {
    id: string;
    subject: string;
    message: string;
    sticky: boolean;
    locked: boolean;
    authorId: string;
    categoryId: string;
}