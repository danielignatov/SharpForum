import { faEdit } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Fragment } from 'react';
import { Link } from 'react-router-dom';
import { Category } from '../../app/models/category';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { useTranslation } from 'react-i18next';
import { Container } from 'react-bootstrap';
import RemoveCategoryBtn from '../categories/RemoveCategoryBtn';

interface Props {
    category: Category
}

function AdminCategoryListItem({ category }: Props) {
    const { t } = useTranslation();

    return (
        <Fragment>
            <Container className={category.isPlaceholder ? 'sf-header sf-bg-colored sf-border-colored sf-text-colored' : 'sf-header'}>
                <Row>
                    <Col xs={12} sm={6} md={7} lg={8} xl={9}>
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
                    <Col xs={8} sm={4} md={3} lg={3} xl={2}>
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
                    <Col xs={4} sm={2} md={2} lg={1} xl={1}>
                        <div className="d-grid gap-2 mt-2">
                            <RemoveCategoryBtn categoryId={category.id} categoryName={category.name} />
                        </div>
                    </Col>
                </Row>
            </Container>
        </Fragment>
    );
}

export default AdminCategoryListItem;