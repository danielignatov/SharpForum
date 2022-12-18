import Col from 'react-bootstrap/Col';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';

interface Props {
    title: string,
    subtitle?: string
}

function Heading({ title, subtitle }: Props) {
    return (
        <Container className='sf-header'>
            <Row>
                <Col>
                    <strong>{title}</strong>
                </Col>
            </Row>
            {subtitle &&
                <Row>
                    <Col>
                        <small>{subtitle}</small>
                    </Col>
                </Row>
            }
        </Container>
    );
}

export default Heading;