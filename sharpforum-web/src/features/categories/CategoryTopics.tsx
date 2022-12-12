import React, { Fragment, useEffect } from 'react';
import { observer } from 'mobx-react';
import { useStore } from '../../app/stores/store';
import Loading from '../../layouts/Loading';
import TopicList from '../topics/TopicList';

interface Props {
    categoryId: string
}

export default observer(function CategoryTopics({ categoryId }: Props) {
    const { topicStore } = useStore();
    const { loading, topicsByCategory, loadTopicsByCategory } = topicStore;

    useEffect(() => {
        loadTopicsByCategory(categoryId ?? '');
    }, [categoryId, loadTopicsByCategory])

    return (
        <Fragment>
            {loading ? (
                <Loading />
            ) : (
                <TopicList topics={topicsByCategory} />
            )}
        </Fragment>
    );
});