import { Category } from '../../app/models/category';
import { useStore } from '../../app/stores/store';
import { Fragment, useEffect } from 'react';
import { observer } from 'mobx-react';
import AdminCategoryListItem from './AdminCategoryListItem';
import { Container } from 'react-bootstrap';
import AddCategoryForm from '../categories/AddCategoryForm';
import AdminCategoryListHeader from './AdminCategoryListHeader';
import AdminCategoryListPlaceholder from '../placeholders/AdminCategoryListPlaceholder';

export default observer(function AdminCategoryList() {
    const { categoryStore } = useStore();
    const { loading, categories, loadCategories } = categoryStore;

    useEffect(() => {
        if (categories.length < 1) loadCategories();
    }, [categories.length, loadCategories])

    return (
        <Fragment>
            <AdminCategoryListHeader />
            <Container className='sf-container'>
                <div className='pb-3'>
                    {loading ? (
                        <AdminCategoryListPlaceholder />
                    ) : (
                        <Fragment>
                            {categories.map((category: Category) => (
                                <AdminCategoryListItem key={category.id} category={category} />
                            ))}
                        </Fragment>
                    )}
                </div>
                <AddCategoryForm />
            </Container>
        </Fragment>
    );
});