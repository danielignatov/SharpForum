import CategoryList from '../features/categories/CategoryList';
import { Fragment } from 'react';
import { Route, Routes } from 'react-router-dom';
import Layout from './Layout';
import CategoryDetails from '../features/categories/CategoryDetails';
import ErrorPage from './ErrorPage';

function App() {
    return (
        <Fragment>
            <Routes>
                <Route path="/" element={<Layout />} errorElement={<ErrorPage />}>
                    <Route index element={<CategoryList />} />
                    <Route path="category/:categoryId" element={<CategoryDetails />} />
                    <Route path="topic/:topicId" element={<CategoryDetails />} />
                    <Route path="*" element={<CategoryDetails />} />
                </Route>
            </Routes>
        </Fragment>
    );
}

export default App;