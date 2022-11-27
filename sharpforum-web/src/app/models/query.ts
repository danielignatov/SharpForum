export interface Query {
    operationName: string;
    query: string;
    variables: {}
}

export class Query implements Query {
    constructor(operationName: string, query: string, variables: {}) {
        this.operationName = operationName;
        this.query = query;
        this.variables = variables
    }
}