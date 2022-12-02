import CategoryList from '../features/categories/CategoryList';
import { Fragment } from 'react';
import { Route, Routes } from 'react-router-dom';
import Layout from './Layout';
import CategoryDetails from '../features/categories/CategoryDetails';
import ErrorPage from './ErrorPage';
import TopicAddForm from '../features/topics/TopicAddForm';
import TopicDetails from '../features/topics/TopicDetails';
import UserLoginForm from '../features/users/UserLoginForm';
import UserRegisterForm from '../features/users/UserRegisterForm';
import UserDetails from '../features/users/UserDetails';
import NotFound from './NotFound';
import PrivacyPolicy from './PrivacyPolicy';

function App() {
    return (
        <Fragment>
            <Routes>
                <Route path="/" element={<Layout />} errorElement={<ErrorPage />}>
                    <Route index element={<CategoryList />} />
                    <Route path="category/:categoryId" element={<CategoryDetails />} />
                    <Route path="topic/add" element={<TopicAddForm />} />
                    <Route path="topic/:topicId" element={<TopicDetails />} />
                    <Route path="login" element={<UserLoginForm />} />
                    <Route path="register" element={<UserRegisterForm />} />
                    <Route path="user/:userId" element={<UserDetails />} />
                    <Route path="privacy" element={<PrivacyPolicy />} />
                    <Route path="*" element={<NotFound />} />
                </Route>
            </Routes>
        </Fragment>
    );
}

export default App;