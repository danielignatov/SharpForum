import { faBars } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import Container from 'react-bootstrap/Container';
import { useTranslation } from 'react-i18next';

function AdminCategoryListHeader() {
    const { t } = useTranslation();

    return (
        <Container className='sf-header-colored'>
            <strong><FontAwesomeIcon icon={faBars} /> {t('admin.categories.edit')}</strong>
        </Container>
    );
}

export default AdminCategoryListHeader;