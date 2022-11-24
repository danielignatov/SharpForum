import React from 'react';
import ReactDOM from 'react-dom/client';
import { ApolloClient, InMemoryCache, ApolloProvider } from '@apollo/client';
import './index.css';
import App from './layouts/App';
import reportWebVitals from './reportWebVitals';
//import { dataStore, DataStoreContext } from './app/data/dataStore';
import 'bootstrap/dist/css/bootstrap.min.css';
import {
    createBrowserRouter,
    RouterProvider,
    Route,
} from "react-router-dom";

const client = new ApolloClient({
    uri: 'http://localhost:5000/graphql/',
    cache: new InMemoryCache()
});

const router = createBrowserRouter([
    {
        path: "/",
        element: <div>Hello world!</div>,
    },
]);

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

//<DataStoreContext.Provider value={dataStore}>
//</DataStoreContext.Provider>

root.render(
    <React.StrictMode>
        <ApolloProvider client={client}>
            <App />
        </ApolloProvider>
    </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();