import { Category } from '../../app/models/category';
import CategoryListItem from './CategoryListItem';
//import Loading from '../../layouts/Loading';
import { useStore } from '../../app/stores/store';
import { Fragment, useEffect } from 'react';
//import { Placeholder } from 'react-bootstrap';
import { observer } from 'mobx-react';
import { useTranslation } from 'react-i18next';
import Heading from '../../layouts/Heading';
import CategoryListItemPlaceholder from './CategoryListItemPlaceholder';

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
                <Fragment>
                    <CategoryListItemPlaceholder categoryNameSize={3} categoryDescSize={8} isPlaceholder={true} />
                    <CategoryListItemPlaceholder categoryNameSize={4} categoryDescSize={7} />
                    <CategoryListItemPlaceholder categoryNameSize={5} categoryDescSize={6} />
                    <CategoryListItemPlaceholder categoryNameSize={4} categoryDescSize={7} isPlaceholder={true} />
                    <CategoryListItemPlaceholder categoryNameSize={3} categoryDescSize={6} />
                    <CategoryListItemPlaceholder categoryNameSize={5} categoryDescSize={8} />
                </Fragment>
            ) : (
                <Fragment>
                    <div className='pb-2'>
                        {categories.map((category: Category) => (
                            <CategoryListItem key={category.id} category={category} />
                        ))}
                    </div>
                </Fragment>
            )}
        </Fragment>
    );
});