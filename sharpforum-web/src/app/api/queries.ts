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
        return new Query(
            "getCategoryTopicsQuery",
            `query getCategoryTopicsQuery($categoryId: UUID) { topics (where: {categoryId: {eq: $categoryId}} ) { id, subject, locked, authorId, author { displayName }, categoryId, category { name }, createdOn } }`,
            { "categoryId": categoryId });
    },
    getTopicQuery(topicId: string) {
        return new Query(
            "getTopicQuery",
            `query getTopicQuery($topicId: UUID) { topics (where: {id: {eq: $topicId}} ) { id, subject, message, locked, authorId, author { displayName }, categoryId, category { name }, createdOn } }`,
            { "topicId": topicId });
    },
    getTopicRepliesQuery(topicId: string) {
        return new Query(
            "getTopicRepliesQuery",
            `query getTopicRepliesQuery($topicId: UUID) { replies (where: {topicId: {eq: $topicId}} ) { id, message, authorId, author { displayName }, createdOn } }`,
            { "topicId": topicId });
    },
    getUserQuery(userId: string) {
        return new Query(
            "getUserQuery",
            `query getUserQuery($userId: UUID) { users (where: {id: {eq: $userId}} ) { id, displayName, about, location, createdOn } }`,
            { "userId": userId });
    },
    mutateLoginUserQuery(displayName: string, password: string) {
        return new Query(
            "loginUser",
            `mutation loginUser($displayName: String, $password: String) { loginUser(input: { displayName: $displayName, password: $password }) { token, expiration, user { id, displayName, email, roleId, role { id, name }} }}`,
            { "displayName": displayName, "password": password });
    },
    mutateRegisterUserQuery(displayName: string, password: string) {
        return new Query(
            "registerUser",
            `mutation registerUser($displayName: String, $password: String) { loginUser(input: { displayName: $displayName, password: $password }) { token, expiration, user { id, displayName, email, roleId, role { id, name }} }}`,
            { "displayName": displayName, "password": password });
    }
}

export default queries;