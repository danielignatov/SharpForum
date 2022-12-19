import { Fragment } from 'react';
import { useTranslation } from 'react-i18next';
import { useNavigate } from 'react-router-dom';
import { useStore } from '../../app/stores/store';
import Heading from '../../layouts/Heading';
import AdminCategoryList from './AdminCategoryList';

function AdminDashboard() {
    const { t } = useTranslation();
    const { userStore } = useStore();
    const { isAdmin } = userStore;
    const navigate = useNavigate();

    if (!isAdmin) {
        navigate(`/login`);
    }

    return (
        <Fragment>
            <Heading title={t('admin.dash')} subtitle={t('admin.dash-desc') ?? ''} colored={true} />
            <AdminCategoryList />
        </Fragment>
    );
}

export default AdminDashboard;