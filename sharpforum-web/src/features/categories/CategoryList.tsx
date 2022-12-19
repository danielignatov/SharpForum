import { Category } from '../../app/models/category';
import CategoryListItem from './CategoryListItem';
import { useStore } from '../../app/stores/store';
import { Fragment, useEffect } from 'react';
import { observer } from 'mobx-react';
import { useTranslation } from 'react-i18next';
import Heading from '../../layouts/Heading';
import CategoryListPlaceholder from '../placeholders/CategoryListPlaceholder';

export default observer(function CategoryList() {
    const { t } = useTranslation();
    const { categoryStore } = useStore();
    const { loading, categories, loadCategories } = categoryStore;

    useEffect(() => {
        if (categories.length <= 1) loadCategories();
    }, [categories.length, loadCategories])

    return (
        <Fragment>
            <Heading title={t('categories.title')} colored={false} />
            {loading ? (
                <CategoryListPlaceholder />
            ) : (
                <div className='pb-2'>
                    {categories.map((category: Category) => (
                        <CategoryListItem key={category.id} category={category} />
                    ))}
                </div>
            )}
        </Fragment>
    );
});