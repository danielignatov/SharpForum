import { observer } from 'mobx-react';
import React, { Fragment, useEffect } from 'react';
import Button from 'react-bootstrap/Button';
import { useParams } from 'react-router-dom';
import Loading from '../../layouts/Loading';
import TopicList from '../topics/TopicList';
import { useStore } from '../../app/stores/store';

export default observer(function CategoryDetails() {
    const { categoryId } = useParams<{ categoryId: string }>();
    const { topicStore } = useStore();
    const { loading, topicsByCategory, loadTopicsByCategory } = topicStore;

    useEffect(() => {
        loadTopicsByCategory(categoryId ?? '');
    }, [categoryId, loadTopicsByCategory])

    return (
        <Fragment>
            { loading ? (
                <Loading />
            ) : (
                <Fragment>
                    <Button variant='success' className='sf-mb-1'>Add Topic</Button>
                    <TopicList topics={topicsByCategory} />
                </Fragment>
            )}
        </Fragment>
    );
});