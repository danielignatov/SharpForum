import './Navigation.scss';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { Link } from 'react-router-dom';
import { observer } from 'mobx-react';
import { useStore } from '../../app/stores/store';
import { useTranslation } from 'react-i18next';
import Language from './Language';
import NavDropdown from 'react-bootstrap/NavDropdown';

//<Nav.Link as={Link} to={`/search`}>Search</Nav.Link>

export default observer(function Navigation() {
    const { t } = useTranslation();
    const { userStore } = useStore();
    const { isLoggedIn, isAdmin, currentUser, logout } = userStore;

    //useEffect(() => {
    //    if (categories.length <= 1) loadCategories();
    //}, [categories.length, loadCategories])

    return (
        <Navbar bg="primary" variant="dark" className="sf-navbar" >
            <Container>
                <Navbar.Brand as={Link} to={`/`}>SharpForum</Navbar.Brand>
                <Nav className="me-auto">
                    <Nav.Link as={Link} to={`/`}>{t('layout.nav.home')}</Nav.Link>
                    <Nav.Link as={Link} to={`/users`}>{t('layout.nav.users')}</Nav.Link>
                    <Language />
                </Nav>
                {isLoggedIn ? (
                    <Nav>
                        <NavDropdown title={`${t('layout.nav.greet')}, ${currentUser?.displayName}`}>
                            <NavDropdown.Item as={Link} to={`/user/${currentUser?.id}`}>{t('common.profile')}</NavDropdown.Item>
                            {isAdmin && 
                                <NavDropdown.Item as={Link} to={`/admin`}>{t('admin.dash')}</NavDropdown.Item>
                            }
                            <NavDropdown.Item onClick={logout}>{t('layout.nav.logout')}</NavDropdown.Item>
                        </NavDropdown>
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