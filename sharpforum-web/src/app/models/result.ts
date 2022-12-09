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

export interface TopicResult {
    success: boolean;
    topicId: string;
    errors: string[];
}

export class TopicResult implements TopicResult {
    constructor(success: boolean, topicId: string, errors: string[]) {
        this.success = success;
        this.topicId = topicId;
        this.errors = errors;
    }
}