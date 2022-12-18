import { observer } from 'mobx-react';
import { Fragment, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Loading from '../../layouts/Loading';
import { useStore } from '../../app/stores/store';
import Table from 'react-bootstrap/Table';
import Row from 'react-bootstrap/Row';
import ReplyList from '../replies/ReplyList';
import { useTranslation } from 'react-i18next';
import AddReplyForm from '../replies/AddReplyForm';
import Container from 'react-bootstrap/Container';
import { Topic } from '../../app/models/topic';
import TopicBody from './TopicBody';

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
                    <Container className='sf-header'>
                        <Row>
                            <strong>{t('topics.singular')}</strong>
                        </Row>
                    </Container>
                    <Table bordered bgcolor='white'>
                        <tbody>
                            <tr>
                                <td>
                                    <TopicBody topic={selectedTopic ?? new Topic()} />
                                </td>
                            </tr>
                        </tbody>
                    </Table>
                    <ReplyList />
                    <AddReplyForm topicId={topicId ?? ''} />
                </Fragment>
            )}
        </Fragment>
    );
});