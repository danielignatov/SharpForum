import Placeholder from 'react-bootstrap/Placeholder';
import Col from 'react-bootstrap/Col';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';

interface Props {
    titleSize: number,
    colored?: boolean,
    subtitleSize?: number
}

function HeadingPlaceholder({ titleSize, colored, subtitleSize }: Props) {
    return (
        <Container className={colored ? 'sf-header-colored' : 'sf-header'}>
            <Row>
                <Col>
                    <Placeholder as="strong" animation="wave">
                        <Placeholder xs={titleSize} />
                    </Placeholder>
                </Col>
            </Row>
            {subtitleSize &&
                <Row>
                    <Col>
                        <Placeholder as="small" animation="wave">
                            <Placeholder xs={subtitleSize} />
                        </Placeholder>
                    </Col>
                </Row>
            }
        </Container>
    );
}

export default HeadingPlaceholder;