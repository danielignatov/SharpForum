import axios, { AxiosResponse } from 'axios';
import queries from './queries';

const endpoint = "http://localhost:5000/graphql/";

const token = window.localStorage.getItem('jwt') || '';

const headers = {
    "content-type": "application/json",
    "Authorization": `Bearer ${token}`
};

axios.defaults.baseURL = 'http://localhost:5000';

const responseBody = (response: AxiosResponse) => response.data;

const requests = {
    //.then(sleep(1000)) to test with delay
    //get: (url: string) => axios.get(url).then(responseBody),
    //post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
    //put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
    //del: (url: string) => axios.delete(url).then(responseBody),
    //postForm: (url: string, file: Blob) => {
    //    let formData = new FormData();
    //    formData.append('File', file);
    //    return axios.post(url, formData, {
    //        headers: { 'Content-type': 'multipart/form-data' }
    //    }).then(responseBody);
    //},
    graphql: (query: any) => axios({
        url: endpoint,
        method: 'post',
        headers: headers,
        data: query
    }).then(responseBody)
}

const Replies = {
    byTopicId: (topicId: string) => requests.graphql(queries.getTopicRepliesQuery(topicId)),
    add: (authorId: string, topicId: string, message: string) => requests.graphql(queries.addTopicReplyQuery(authorId, topicId, message))
}

const Categories = {
    all: () => requests.graphql(queries.getAllCategoriesQuery),
    add: (name: string, description: string, displayOrder: number, isPlaceholder: boolean) => requests.graphql(queries.addCategoryQuery(name, description, displayOrder, isPlaceholder)),
    edit: (categoryId: string, name: string, description: string, displayOrder: number, isPlaceholder: boolean) => requests.graphql(queries.editCategoryQuery(categoryId, name, description, displayOrder, isPlaceholder)),
    remove: (categoryId: string) => requests.graphql(queries.removeCategoryQuery(categoryId))
}

const Topics = {
    all: () => requests.graphql(queries.getAllTopicsQuery),
    byCategory: (categoryId: string) => requests.graphql(queries.getCategoryTopicsQuery(categoryId)),
    byId: (topicId: string) => requests.graphql(queries.getTopicQuery(topicId)),
    add: (authorId: string, categoryId: string, subject: string, message: string, sticky: boolean, locked: boolean) => requests.graphql(queries.addTopicQuery(authorId, categoryId, subject, message, sticky, locked))
}

const Users = {
    all: () => requests.graphql(queries.getAllUsersQuery),
    login: (displayName: string, password: string) => requests.graphql(queries.mutateLoginUserQuery(displayName, password)),
    register: (displayName: string, password: string, email: string) => requests.graphql(queries.mutateRegisterUserQuery(displayName, password, email)),
    byId: (userId: string) => requests.graphql(queries.getUserQuery(userId)),
    current: () => requests.graphql(queries.getCurrentUserQuery())
}

const agent = {
    Categories,
    Topics,
    Replies,
    Users
}

export default agent;