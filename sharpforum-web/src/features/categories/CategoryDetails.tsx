import { observer } from 'mobx-react';
import React, { Fragment, useEffect } from 'react';
import { useParams } from 'react-router-dom';
//import Loading from '../../layouts/Loading';
import { useStore } from '../../app/stores/store';
import AddTopicBtn from '../topics/AddTopicBtn';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Placeholder from 'react-bootstrap/Placeholder';
import CategoryTopics from './CategoryTopics';
//import { useTranslation } from 'react-i18next';

export default observer(function CategoryDetails() {
    //const { t } = useTranslation();
    const { categoryId } = useParams<{ categoryId: string }>();
    const { categoryStore } = useStore();
    const { loadingCategory, category, loadCategory } = categoryStore;

    useEffect(() => {
        loadCategory(categoryId ?? '');
    }, [categoryId, loadingCategory])

    return (
        <Fragment>
            {loadingCategory ? (
                <Fragment>
                    <Placeholder.Button xs={4} aria-hidden="true" />
                    <Container className='sf-header'>
                        <Placeholder as="p" animation="wave">
                            <Placeholder xs={4} />
                        </Placeholder>
                        <Placeholder as="small" animation="wave">
                            <Placeholder xs={6} />
                        </Placeholder>
                    </Container>
                </Fragment>
            ) : (
                <Fragment>
                    <AddTopicBtn categoryId={categoryId ?? ''} />
                    <Container className='sf-header'>
                        <Row>
                            <strong>{category?.name}</strong>
                        </Row>
                        <Row>
                            <small>{category?.description}</small>
                        </Row>
                    </Container>
                    <CategoryTopics categoryId={categoryId ?? ''} />
                </Fragment>
            )}
        </Fragment>
    );
});