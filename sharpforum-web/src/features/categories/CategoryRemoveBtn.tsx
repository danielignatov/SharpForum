import { faTrashCan } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Fragment, useState } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import { useTranslation } from 'react-i18next';
import { useStore } from '../../app/stores/store';

interface Props {
    categoryId: string,
    categoryName: string
}

function CategoryRemoveBtn({ categoryId, categoryName }: Props) {
    const { t } = useTranslation();
    const { categoryStore } = useStore();
    const { remove } = categoryStore;
    const [show, setShow] = useState(false);
    const btnTitle = t('admin.categories.delete-modal-title');

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    const handleRemove = () => {
        remove(categoryId);
        handleClose();
    };

    return (
        <Fragment>
            <div className="d-grid gap-2 mt-2">
                <Button variant="danger" onClick={handleShow} className="text-white" title={btnTitle}>
                    <FontAwesomeIcon icon={faTrashCan} />
                </Button>
            </div>

            <Modal show={show} onHide={handleClose} centered>
                <Modal.Header closeButton>
                    <Modal.Title>{t('admin.categories.delete-modal-title')}</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <p>
                        {`${t('admin.categories.delete-modal-text-p1')} "${categoryName}" ${t('admin.categories.delete-modal-text-p2')}.`}
                    </p>
                    <Row>
                        <Col>
                            <div className="d-grid gap-2">
                                <Button variant="secondary" onClick={handleClose} className="text-white">
                                    {t('common.cancel')}
                                </Button>
                            </div>
                        </Col>
                        <Col>
                            <div className="d-grid gap-2">
                                <Button variant="danger" onClick={handleRemove} className="text-white">
                                    {t('common.confirm')}
                                </Button>
                            </div>
                        </Col>
                    </Row>
                </Modal.Body>
            </Modal>
        </Fragment>
    );
}

export default CategoryRemoveBtn;