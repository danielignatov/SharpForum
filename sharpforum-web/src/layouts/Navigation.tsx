import './Navigation.scss';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { Link } from 'react-router-dom';
import { observer } from 'mobx-react';
import { useStore } from '../app/stores/store';

//<Nav.Link as={Link} to={`/search`}>Search</Nav.Link>

export default observer(function Navigation() {
    const { userStore } = useStore();
    const { isLoggedIn, user } = userStore;

    //useEffect(() => {
    //    if (categories.length <= 1) loadCategories();
    //}, [categories.length, loadCategories])

    return (
        <Navbar bg="primary" variant="dark" className="sf-navbar" >
            <Container>
                <Navbar.Brand as={Link} to={`/`}>SharpForum</Navbar.Brand>
                <Nav className="me-auto">
                    <Nav.Link as={Link} to={`/`}>Home</Nav.Link>
                </Nav>
                {isLoggedIn ? (
                    <Nav>
                        <Nav.Link as={Link} to={`/user/${user?.id}`}>Hi, {user?.displayName}</Nav.Link>
                        <Nav.Link as={Link} to={`/logout`}>Logout</Nav.Link>
                    </Nav>
                ) : (
                    <Nav>
                        <Nav.Link as={Link} to={`/login`}>Login</Nav.Link>
                        <Nav.Link as={Link} to={`/register`}>Register</Nav.Link>
                    </Nav>
                )}
            </Container>
        </Navbar>
    );
});