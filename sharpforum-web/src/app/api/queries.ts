import { Query } from "../models/query";

const getAllCategoriesQuery: Query = {
    "operationName": "getAllCategories",
    "query": `query getAllCategories { categories { id, name, description, displayOrder, isPlaceholder } }`,
    "variables": {}
};

const getAllTopicsQuery: Query = {
    "operationName": "getAllTopicsQuery",
    "query": `query getAllTopicsQuery { topics { id, subject, locked, authorId, author { displayName }, categoryId, category { name }, createdOn } }`,
    "variables": {}
};

const queries = {
    getAllCategoriesQuery,
    getAllTopicsQuery,

    getCategoryTopicsQuery(categoryId: string) {
        return new Query("getCategoryTopicsQuery", `query getCategoryTopicsQuery($categoryId: UUID) { topics (where: {categoryId: {eq: $categoryId}} ) { id, subject, locked, authorId, author { displayName }, categoryId, category { name }, createdOn } }`, categoryId);
    }
}

export default queries;