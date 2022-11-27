import Table from 'react-bootstrap/Table';
import './CategoryList.css';
import { Category } from '../../app/models/category';
import CategoryListItem from './CategoryListItem';
import Loading from '../../layouts/Loading';
import { useStore } from '../../app/stores/store';
import { Fragment, useEffect } from 'react';
//import { Placeholder } from 'react-bootstrap';
import { observer } from 'mobx-react';

export default observer( function CategoryList() {
    const { categoryStore } = useStore();
    const { loading, categories, loadCategories } = categoryStore;

    useEffect(() => {
        if (categories.length <= 1) loadCategories();
    }, [categories.length, loadCategories])

    return (
        <Fragment>
            { loading ? (
                //<Placeholder as={Table}>
                //    <Placeholder xs={4} animation='wave' />
                //</Placeholder>
                <Loading />
            ) : (
                <Table bordered>
                    <thead>
                        <tr>
                            <th>Categories</th>
                        </tr>
                    </thead>
                    <tbody>
                        {categories.map((category: Category) => (
                            <CategoryListItem key={category.id} category={category} />
                        ))}
                    </tbody>
                </Table>
            )}
        </Fragment>
    );
})