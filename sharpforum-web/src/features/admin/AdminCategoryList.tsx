import Table from 'react-bootstrap/Table';
//import './CategoryList.scss';
import { Category } from '../../app/models/category';
//import CategoryListItem from './CategoryListItem';
import Loading from '../../layouts/Loading';
import { useStore } from '../../app/stores/store';
import { Fragment, useEffect } from 'react';
//import { Placeholder } from 'react-bootstrap';
import { observer } from 'mobx-react';
import { useTranslation } from 'react-i18next';

export default observer(function AdminCategoryList() {
    const { t } = useTranslation();
    const { categoryStore } = useStore();
    const { loading, categories, loadCategories } = categoryStore;

    useEffect(() => {
        if (categories.length <= 1) loadCategories();
    }, [categories.length, loadCategories])

    return (
        <Fragment>
            {loading ? (
                //<Placeholder as={Table}>
                //    <Placeholder xs={4} animation='wave' />
                //</Placeholder>
                <Loading />
            ) : (
                <Table bordered bgcolor='white'>
                    <thead>
                        <tr>
                            <th>{t('categories.title')}</th>
                        </tr>
                    </thead>
                    <tbody>
                            {categories.map((category: Category) => (
                                <Fragment></Fragment>
                            /*<CategoryListItem key={category.id} category={category} />*/
                        ))}
                    </tbody>
                </Table>
            )}
        </Fragment>
    );
});