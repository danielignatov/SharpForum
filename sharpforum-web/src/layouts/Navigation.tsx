import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { Link } from 'react-router-dom';

function Navigation() {
  return (
      <Navbar bg="primary" variant="dark">
          <Container>
              <Navbar.Brand as={Link} to={`/`}>SharpForum</Navbar.Brand>
              <Nav className="me-auto">
                  <Nav.Link as={Link} to={`/`}>Home</Nav.Link>
                  <Nav.Link as={Link} to={`/search`}>Search</Nav.Link>
              </Nav>
              <Nav>
                  <Nav.Link as={Link} to={`/login`}>Login</Nav.Link>
                  <Nav.Link as={Link} to={`/register`}>Register</Nav.Link>
              </Nav>
          </Container>
      </Navbar>
  );
}

export default Navigation;