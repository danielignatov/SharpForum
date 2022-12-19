import { Fragment } from 'react';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Container from 'react-bootstrap/Container';
import Placeholder from 'react-bootstrap/Placeholder';
import HeadingPlaceholder from '../../layouts/HeadingPlaceholder';

interface Props {
    categoryNameSize: number,
    categoryDescSize: number,
    isPlaceholder?: boolean
}

function CategoryListItemPlaceholder({ categoryNameSize, categoryDescSize, isPlaceholder }: Props) {
    return (
        <Fragment>
            {isPlaceholder ? (
                <HeadingPlaceholder titleSize={categoryNameSize} colored={true} />
            ) : (
                <Fragment>
                    <Container className='sf-header'>
                        <Row>
                            <Col xs={12} sm={9} md={6}>
                                <Placeholder as="strong" animation="wave">
                                    <Placeholder xs={categoryNameSize} />
                                </Placeholder>
                            </Col>
                            <Col xs={0} sm={3} md={6}>
                                <Placeholder as="small" animation="wave">
                                    <Placeholder xs={3} />
                                </Placeholder>
                            </Col>
                        </Row>
                        <Row>
                            <Col xs={12} sm={9} md={6}>
                                <Placeholder as="small" animation="wave">
                                    <Placeholder xs={categoryDescSize} />
                                </Placeholder>
                            </Col>
                            <Col xs={0} sm={3} md={6}>
                                <Placeholder as="small" animation="wave">
                                    <Placeholder xs={2} />
                                </Placeholder>
                            </Col>
                        </Row>
                    </Container>
                </Fragment>
            )}

        </Fragment>
    );
}

export default CategoryListItemPlaceholder;