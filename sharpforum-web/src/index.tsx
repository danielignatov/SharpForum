import React from 'react';
import ReactDOM from 'react-dom/client';
import { ApolloClient, InMemoryCache, ApolloProvider } from '@apollo/client';
import './index.css';
import App from './layouts/App';
//import ErrorPage from './layouts/ErrorPage';
//import { Category } from './app/models/category';
import reportWebVitals from './reportWebVitals';
//import { dataStore, DataStoreContext } from './app/data/dataStore';
import 'bootstrap/dist/css/bootstrap.min.css';
//import {
//    createBrowserRouter,
//    RouterProvider,
//    //Route,
//} from "react-router-dom";
//import TopicList from './features/topics/TopicList';
//import CategoryDetails from './features/categories/CategoryDetails';
import { BrowserRouter } from "react-router-dom";

const client = new ApolloClient({
    uri: 'http://localhost:5000/graphql/',
    cache: new InMemoryCache()
});

//const router = createBrowserRouter([
//    {
//        path: "/",
//        element: <App />,
//        errorElement: <ErrorPage />,
//        children: [
//            {
//                path: "category/:categoryId",
//                element: <CategoryDetails />
//            },
//            {
//                path: "*",
//                element: <CategoryDetails />
//            }
//        ]
//    },
//]);

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

//<DataStoreContext.Provider value={dataStore}>
//</DataStoreContext.Provider>

//<RouterProvider router={router} />
root.render(
    <React.StrictMode>
        <ApolloProvider client={client}>
            <BrowserRouter>
                <App />
            </BrowserRouter>
        </ApolloProvider>
    </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();