import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Outlet } from 'react-router-dom';
import Navigation from './Navigation';

function Layout() {
  return (
      <Container>
          <Row>
              <Col>
                  <Navigation />
              </Col>
          </Row>
          <Row>
              <Col>
                  <Outlet />
              </Col>
          </Row>
      </Container>
  );
}

export default Layout;