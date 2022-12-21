import { Fragment } from 'react';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Container from 'react-bootstrap/Container';
import Placeholder from 'react-bootstrap/Placeholder';

interface Props {
    categoryNameSize: number,
    categoryDescSize: number,
    isPlaceholder?: boolean
}

function AdminCategoryListItemPlaceholder({ categoryNameSize, categoryDescSize, isPlaceholder }: Props) {
    return (
        <Fragment>
            <Container className={isPlaceholder ? 'sf-header sf-bg-colored sf-border-colored sf-text-colored' : 'sf-header'}>
                <Row>
                    <Col xs={12} sm={8}>
                        <Row>
                            <Col xs={6}>
                                <Placeholder as="strong" animation="wave">
                                    <Placeholder xs={categoryNameSize} />
                                </Placeholder>
                            </Col>
                            <Col xs={6}>
                                <Placeholder as="small" animation="wave">
                                    <Placeholder xs={3} />
                                </Placeholder>
                            </Col>
                        </Row>
                        <Row>
                            <Col>
                                <Placeholder as="small" animation="wave">
                                    <Placeholder xs={categoryDescSize} />
                                </Placeholder>
                            </Col>
                        </Row>
                    </Col>
                    <Col xs={12} sm={4}>
                        <div className="d-grid gap-2 mt-2">
                            <Placeholder.Button variant="secondary" aria-hidden="true" />
                        </div>
                    </Col>
                </Row>
            </Container>
        </Fragment>
    );
}

export default AdminCategoryListItemPlaceholder;