import { Fragment } from 'react';
import { Link } from 'react-router-dom';
import { Category } from '../../app/models/category';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { useTranslation } from 'react-i18next';
import ReplyCount from '../replies/ReplyCount';
import { Container } from 'react-bootstrap';
import Heading from '../../layouts/Heading';

interface Props {
    category: Category
}

function CategoryListItem({ category }: Props) {
    const { t } = useTranslation();

    return (
        <Fragment>
            {category.isPlaceholder ? (
                <Heading title={category.name} colored={true} />
            ) : (
                <Link to={`/category/${category.id}`} className='sf-link-no-underline'>
                    <Container className='sf-header'>
                        <Row>
                            <Col xs={12} sm={9} md={6}>
                                <strong>{category.name}</strong>
                            </Col>
                            <Col xs={0} sm={3} md={6}>
                                <small>{category.topicCount} {t('topics.title-l')}</small>
                            </Col>
                        </Row>
                        <Row>
                            <Col xs={12} sm={9} md={6}>
                                <small>{category.description}</small>
                            </Col>
                            <Col xs={0} sm={3} md={6}>
                                <ReplyCount value={category.replyCount} />
                            </Col>
                        </Row>
                    </Container>
                </Link>
            )}

        </Fragment>
    );
}

export default CategoryListItem;