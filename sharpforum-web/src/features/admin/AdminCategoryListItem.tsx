import { faEdit } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Fragment } from 'react';
import { Link } from 'react-router-dom';
import { Category } from '../../app/models/category';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { useTranslation } from 'react-i18next';
import { Container } from 'react-bootstrap';

interface Props {
    category: Category
}

function AdminCategoryListItem({ category }: Props) {
    const { t } = useTranslation();

    return (
        <Fragment>
            <Container className={category.isPlaceholder ? 'sf-header sf-bg' : 'sf-header'}>
                <Row>
                    <Col xs={12} sm={8}>
                        <Row>
                            <Col xs={6}>
                                <strong>{category.name}</strong>
                            </Col>
                            <Col xs={6}>
                                <small>{`${t('admin.categories.displayOrder')}: ${category.displayOrder}`}</small>
                            </Col>
                        </Row>
                        <Row>
                            <Col>
                                <small>{category.description}</small>
                            </Col>
                        </Row>
                    </Col>
                    <Col xs={12} sm={4}>
                        <div className="d-grid gap-2 mt-2">
                            <Link
                                className="btn btn-secondary text-white"
                                role="button"
                                to={`/category/${category.id}/edit`}
                            >
                                <FontAwesomeIcon icon={faEdit} /> {t('common.edit')}
                            </Link>
                        </div>
                    </Col>
                </Row>
            </Container>
        </Fragment>
    );
}

export default AdminCategoryListItem;