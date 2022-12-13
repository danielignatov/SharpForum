import { Fragment } from 'react';
import { Link } from 'react-router-dom';
import { Category } from '../../app/models/category';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { useTranslation } from 'react-i18next';

interface Props {
    category: Category
}

function CategoryListItem({ category }: Props) {
    const { t } = useTranslation();

    return (
        <Fragment>
            {category.isPlaceholder ? (
                <tr className='placeholder-category'>
                    <td>
                        <Row className="pt-1 pb-1">
                            <strong>{category.name}</strong>
                        </Row>
                    </td>
                </tr>
            ) : (
                <tr>
                    <td>
                        <Row>
                            <Col xs={12} sm={9} md={6}>
                                <Link to={`/category/${category.id}`} className='sf-link'>
                                    <strong>{category.name}</strong>
                                </Link>
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
                                <small>{category.replyCount} {t('replies.title-l')}</small>
                            </Col>
                        </Row>
                    </td>
                </tr>
            )}

        </Fragment>
    );
}

export default CategoryListItem;