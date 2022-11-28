import axios, { AxiosResponse } from 'axios';
import queries from './queries';

const endpoint = "http://localhost:5000/graphql/";

const headers = {
    "content-type": "application/json",
    "Authorization": "<token>"
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
    byTopicId: (topicId: string) => requests.graphql(queries.getTopicRepliesQuery(topicId))
}

const Categories = {
    all: () => requests.graphql(queries.getAllCategoriesQuery)
}

const Topics = {
    all: () => requests.graphql(queries.getAllTopicsQuery),
    byCategory: (categoryId: string) => requests.graphql(queries.getCategoryTopicsQuery(categoryId)),
    byId: (topicId: string) => requests.graphql(queries.getTopicQuery(topicId))
}

const agent = {
    Categories,
    Topics,
    Replies
}

export default agent;