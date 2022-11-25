import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Spinner from 'react-bootstrap/Spinner';

function Loading() {
    return (
        <Container>
            <Row className="justify-content-center">
                <Spinner animation="border" role="status" className="d-flex justify-content-center" >
                    <span className="visually-hidden">Loading...</span>
                </Spinner>
            </Row>
        </Container>
    );
}

export default Loading;