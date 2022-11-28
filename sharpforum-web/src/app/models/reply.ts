import { Topic } from "./topic";
import { User } from "./user";

export interface Reply {
    id: string;
    message: string;
    authorId: string;
    author: User;
    topicId: string;
    topic: Topic;
    createdOn: Date | null;
}