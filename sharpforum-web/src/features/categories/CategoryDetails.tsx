import { observer } from 'mobx-react';
import React, { Fragment, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Loading from '../../layouts/Loading';
import TopicList from '../topics/TopicList';
import { useStore } from '../../app/stores/store';
//import { useTranslation } from 'react-i18next';
import AddTopicBtn from '../../layouts/AddTopicBtn';

export default observer(function CategoryDetails() {
    //const { t } = useTranslation();
    const { categoryId } = useParams<{ categoryId: string }>();
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
                <Fragment>
                    <AddTopicBtn />
                    <TopicList topics={topicsByCategory} />
                </Fragment>
            )}
        </Fragment>
    );
});