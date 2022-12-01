import './Navigation.scss';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { Link } from 'react-router-dom';
import { observer } from 'mobx-react';
import { useStore } from '../app/stores/store';
import { useTranslation } from 'react-i18next';

//<Nav.Link as={Link} to={`/search`}>Search</Nav.Link>

export default observer(function Navigation() {
    const { t } = useTranslation();
    const { userStore } = useStore();
    const { isLoggedIn, user, logout } = userStore;

    //useEffect(() => {
    //    if (categories.length <= 1) loadCategories();
    //}, [categories.length, loadCategories])

    return (
        <Navbar bg="primary" variant="dark" className="sf-navbar" >
            <Container>
                <Navbar.Brand as={Link} to={`/`}>SharpForum</Navbar.Brand>
                <Nav className="me-auto">
                    <Nav.Link as={Link} to={`/`}>{t('layouts.navigation.home-link')}</Nav.Link>
                </Nav>
                {isLoggedIn ? (
                    <Nav>
                        <Nav.Link as={Link} to={`/user/${user?.id}`}>{t('layouts.navigation.greet')}, {user?.displayName}</Nav.Link>
                        <Nav.Link onClick={logout}>{t('layouts.navigation.logout-link')}</Nav.Link>
                    </Nav>
                ) : (
                    <Nav>
                            <Nav.Link as={Link} to={`/login`}>{t('common.login')}</Nav.Link>
                            <Nav.Link as={Link} to={`/register`}>{t('common.register')}</Nav.Link>
                    </Nav>
                )}
            </Container>
        </Navbar>
    );
});