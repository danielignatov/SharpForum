import { faTrashCan } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Fragment, useState } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import { useTranslation } from 'react-i18next';
import { useStore } from '../../app/stores/store';

interface Props {
    categoryId: string,
    categoryName: string
}

function RemoveCategoryBtn({ categoryId, categoryName }: Props) {
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
            <Button variant="danger" onClick={handleShow} className="text-white" title={btnTitle}>
                <FontAwesomeIcon icon={faTrashCan} />
            </Button>

            <Modal show={show} onHide={handleClose} centered>
                <Modal.Header closeButton>
                    <Modal.Title>{t('admin.categories.delete-modal-title')}</Modal.Title>
                </Modal.Header>
                <Modal.Body>{`${t('admin.categories.delete-modal-text-p1')} "${categoryName}" ${t('admin.categories.delete-modal-text-p2')}.`}</Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        {t('common.cancel')}
                    </Button>
                    <Button variant="danger" onClick={handleRemove}>
                        {t('common.confirm')}
                    </Button>
                </Modal.Footer>
            </Modal>
        </Fragment>
    );
}

export default RemoveCategoryBtn;