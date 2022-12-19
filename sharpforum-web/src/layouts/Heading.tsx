import Col from 'react-bootstrap/Col';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';

interface Props {
    title: string,
    colored?: boolean,
    subtitle?: string
}

function Heading({ title, colored, subtitle }: Props) {
    return (
        <Container className={colored ? 'sf-header-colored' : 'sf-header' }>
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