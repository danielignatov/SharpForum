import { Query } from "../models/query";

const getAllCategoriesQuery: Query = {
    "operationName": "getAllCategories",
    "query": `query getAllCategories { categories { id, name, description, displayOrder, isPlaceholder, topicCount, replyCount } }`,
    "variables": {}
};

const getAllTopicsQuery: Query = {
    "operationName": "getAllTopicsQuery",
    "query": `query getAllTopicsQuery { topics { id, subject, locked, authorId, author { displayName }, categoryId, category { name }, createdOn, replyCount } }`,
    "variables": {}
};

const getAllUsersQuery: Query = {
    "operationName": "getAllUsers",
    "query": `query getAllUsers { users { id, displayName, roleId, role { id, name }, createdOn, about, avatar } }`,
    "variables": {}
};

const queries = {
    getAllCategoriesQuery,
    getAllTopicsQuery,
    getAllUsersQuery,
    getCategoryTopicsQuery(categoryId: string) {
        return new Query(
            "getCategoryTopicsQuery",
            `query getCategoryTopicsQuery($categoryId: UUID) { topics (where: {categoryId: {eq: $categoryId}} ) { id, subject, locked, authorId, author { displayName }, categoryId, category { name }, createdOn, replyCount } }`,
            { "categoryId": categoryId });
    },
    getTopicQuery(topicId: string) {
        return new Query(
            "getTopicQuery",
            `query getTopicQuery($topicId: UUID) { topics (where: {id: {eq: $topicId}} ) { id, subject, message, locked, authorId, author { displayName, avatar, role { name } }, categoryId, category { name }, createdOn, replyCount } }`,
            { "topicId": topicId });
    },
    addTopicQuery(authorId: string, categoryId: string, subject: string, message: string, sticky: boolean, locked: boolean) {
        return new Query(
            "addTopic",
            `mutation addTopic($authorId: UUID!, $categoryId: UUID!, $subject: String, $message: String, $sticky: Boolean!, $locked: Boolean!) { addTopic(input: { authorId: $authorId, categoryId: $categoryId, subject: $subject, message: $message, sticky: $sticky, locked: $locked }) { topic { id, authorId, categoryId, subject, message, sticky, locked, createdOn, updatedOn, replyCount } } }`,
            { "authorId": authorId, "categoryId": categoryId, "subject": subject, "message": message, "sticky": sticky, "locked": locked });
    },
    getTopicRepliesQuery(topicId: string) {
        return new Query(
            "getTopicRepliesQuery",
            `query getTopicRepliesQuery($topicId: UUID) { replies (where: {topicId: {eq: $topicId}} ) { id, message, authorId, author { displayName, avatar, id, role { id, name } }, createdOn } }`,
            { "topicId": topicId });
    },
    addTopicReplyQuery(authorId: string, topicId: string, message: string) {
        return new Query(
            "addReply",
            `mutation addReply($authorId: UUID!, $topicId: UUID!, $message: String) { addReply(input: { authorId: $authorId, topicId: $topicId, message: $message }) { reply { id, authorId, author { id, displayName, roleId, avatar, role { id, name } }, topicId, message, createdOn, updatedOn } } }`,
            { "authorId": authorId, "topicId": topicId, "message": message });
    },
    getUserQuery(userId: string) {
        return new Query(
            "getUserQuery",
            `query getUserQuery($userId: UUID) { users (where: {id: {eq: $userId}} ) { id, displayName, about, location, createdOn, roleId, role { id, name } } }`,
            { "userId": userId });
    },
    getCurrentUserQuery() {
        return new Query(
            "currentUser",
            `query currentUser { currentUser { id, displayName, about, avatar, location, createdOn, email, roleId, role { id, name } } }`,
            { });
    },
    mutateLoginUserQuery(displayName: string, password: string) {
        return new Query(
            "loginUser",
            `mutation loginUser($displayName: String, $password: String) { loginUser(input: { displayName: $displayName, password: $password }) { token, expiration, user { id, displayName, email, roleId, role { id, name }} }}`,
            { "displayName": displayName, "password": password });
    },
    mutateRegisterUserQuery(displayName: string, password: string, email: string) {
        return new Query(
            "registerUser",
            `mutation registerUser($displayName: String, $password: String, $email: String) { registerUser(input: { displayName: $displayName, password: $password, email: $email }) { token, expiration, user { id, displayName, email, roleId, role { id, name }} }}`,
            { "displayName": displayName, "password": password, "email": email });
    }
}

export default queries;