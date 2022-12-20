import { Category } from '../../app/models/category';
//import CategoryListItem from './CategoryListItem';
import { useStore } from '../../app/stores/store';
import { Fragment, useEffect } from 'react';
//import { Placeholder } from 'react-bootstrap';
import { observer } from 'mobx-react';
import { useTranslation } from 'react-i18next';
import Heading from '../../layouts/Heading';
import CategoryListPlaceholder from '../placeholders/CategoryListPlaceholder';
import AdminCategoryListItem from './AdminCategoryListItem';
import { Container } from 'react-bootstrap';
import AddCategoryForm from '../categories/AddCategoryForm';

export default observer(function AdminCategoryList() {
    const { t } = useTranslation();
    const { categoryStore } = useStore();
    const { loading, categories, loadCategories } = categoryStore;

    useEffect(() => {
        if (categories.length < 1) loadCategories();
    }, [categories.length, loadCategories])

    return (
        <Fragment>
            <Heading title={t('admin.categories.edit')} colored={true} />
            <Container className='sf-container'>
                {loading ? (
                    <CategoryListPlaceholder />
                ) : (
                    <div className='pb-3'>
                        {categories.map((category: Category) => (
                            <AdminCategoryListItem key={category.id} category={category} />
                        ))}
                    </div>
                )}
                <AddCategoryForm />
            </Container>
        </Fragment>
    );
});