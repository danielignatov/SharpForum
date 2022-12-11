import CategoryList from '../features/categories/CategoryList';
import { Fragment, useEffect, useState } from 'react';
import { Route, Routes } from 'react-router-dom';
import Layout from './Layout';
import CategoryDetails from '../features/categories/CategoryDetails';
import ErrorPage from './ErrorPage';
import TopicDetails from '../features/topics/TopicDetails';
import UserLoginForm from '../features/users/UserLoginForm';
import UserRegisterForm from '../features/users/UserRegisterForm';
import UserDetails from '../features/users/UserDetails';
import NotFound from './NotFound';
import PrivacyPolicy from './PrivacyPolicy';
import AddTopicForm from '../features/topics/AddTopicForm';
import { useStore } from '../app/stores/store';
import Loading from './Loading';

function App() {
    const { userStore } = useStore();
    const { loadCurrentUser, token } = userStore;
    const [appLoaded, setAppLoaded] = useState(false);

    useEffect(() => {
        if (token) {
            loadCurrentUser().finally(() => setAppLoaded(true));
        } else {
            setAppLoaded(true);
        }
    }, [loadCurrentUser, token])

    return (
        <Fragment>
            {appLoaded ? (
                <Routes>
                    <Route path="/" element={<Layout />} errorElement={<ErrorPage />}>
                        <Route index element={<CategoryList />} />
                        <Route path="category/:categoryId/topic" element={<AddTopicForm />} />
                        <Route path="category/:categoryId" element={<CategoryDetails />} />
                        <Route path="topic/:topicId" element={<TopicDetails />} />
                        <Route path="login" element={<UserLoginForm />} />
                        <Route path="register" element={<UserRegisterForm />} />
                        <Route path="user/:userId" element={<UserDetails />} />
                        <Route path="privacy" element={<PrivacyPolicy />} />
                        <Route path="*" element={<NotFound />} />
                    </Route>
                </Routes>
            ) : (
                <div className="d-flex align-items-center justify-content-center vh-100">
                    <Loading />
                </div>
            )}

        </Fragment>
    );
}

export default App;