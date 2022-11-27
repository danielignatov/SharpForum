import axios, { AxiosRequestConfig, AxiosResponse } from 'axios';
//import { Category } from "../models/category";
//import { gql, useQuery } from '@apollo/client';
//import { gql } from "react-query";

//const sleep = (delay: number) => {
//    return new Promise((resolve) => {
//        setTimeout(resolve, delay)
//    })
//}

const endpoint = "http://localhost:5000/graphql/";

const headers = {
    "content-type": "application/json",
    "Authorization": "<token>"
};

const getAllCategoriesQuery = {
    "operationName": "getAllCategories",
    "query": `query getAllCategories { categories { id, name, description, displayOrder, isPlaceholder } }`,
    "variables": {}
};

//const response = axios({
//    url: endpoint,
//    method: 'post',
//    headers: headers,
//    data: getAllCategoriesQuery
//});

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


const Categories = {
    all: () => requests.graphql(getAllCategoriesQuery)
}

const agent = {
    Categories
}

export default agent;