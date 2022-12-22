import { observer } from 'mobx-react';
import { Fragment, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Loading from '../../layouts/Loading';
import { useStore } from '../../app/stores/store';
import ReplyList from '../replies/ReplyList';
import { useTranslation } from 'react-i18next';
import AddReplyForm from '../replies/ReplyAddForm';
import { Topic } from '../../app/models/topic';
import TopicBody from './TopicBody';
import Heading from '../../layouts/Heading';
import Container from 'react-bootstrap/Container';

export default observer(function TopicDetails() {
    const { t } = useTranslation();
    const { topicId } = useParams<{ topicId: string }>();
    const { topicStore } = useStore();
    const { loading, selectedTopic, loadSelectedTopic } = topicStore;

    useEffect(() => {
        loadSelectedTopic(topicId ?? '');
    }, [topicId, loadSelectedTopic])

    return (
        <Fragment>
            {loading ? (
                <Loading />
            ) : (
                <Fragment>
                    <Heading title={t('topics.singular')} colored={true} />
                    <div className='pb-3'>
                        <Container className='sf-header'>
                            <TopicBody topic={selectedTopic ?? new Topic()} />
                        </Container>
                    </div>
                    <ReplyList />
                    <AddReplyForm topicId={topicId ?? ''} />
                </Fragment>
            )}
        </Fragment>
    );
});