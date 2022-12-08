import { observer } from 'mobx-react';
import React, { Fragment, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Loading from '../../layouts/Loading';
import { useStore } from '../../app/stores/store';
import Table from 'react-bootstrap/Table';
import Row from 'react-bootstrap/Row';
import ReplyList from '../replies/ReplyList';
import { useTranslation } from 'react-i18next';
import AddReplyForm from '../replies/AddReplyForm';

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
                    <Table bordered bgcolor='white'>
                        <thead>
                            <tr>
                                <th>{t('topics.singular')}</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <Row>
                                        <strong>{selectedTopic?.subject}</strong>
                                    </Row>
                                    <Row>
                                        <small>{selectedTopic?.message}</small>
                                    </Row>
                                    <Row>
                                        <small>{t('common.by')} {selectedTopic?.author.displayName}</small>
                                    </Row>
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