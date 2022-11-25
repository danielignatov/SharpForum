import './App.css';
import CategoryList from '../features/categories/CategoryList';
import { gql, useQuery } from '@apollo/client';
import { Fragment } from 'react';
import { Route, Routes } from 'react-router-dom';
import Layout from './Layout';
import CategoryDetails from '../features/categories/CategoryDetails';
import ErrorPage from './ErrorPage';

const GetAllCategoriesQuery = gql`
    query {
        categories {
          id,
          name,
          description,
          displayOrder,
          isPlaceholder
        }
    }
`;

function App() {
    const { loading, error, data } = useQuery(GetAllCategoriesQuery);

    if (loading) return <p>Loading...</p>;
    if (error) return <pre>{error.message}</pre>

    //console.log('data', data);

    return (
        <Fragment>
            <Routes>
                <Route path="/" element={<Layout />} errorElement={<ErrorPage />}>
                    <Route index element={<CategoryList categories={data.categories} />} />
                    <Route path="category/:categoryId" element={<CategoryDetails />} />
                    <Route path="topic/:topicId" element={<CategoryDetails />} />
                    <Route path="*" element={<CategoryDetails />} />
                </Route>
            </Routes>
        </Fragment>
    );
}

export default App;