import { observer } from 'mobx-react';
import React, { Fragment, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Loading from '../../layouts/Loading';
import { useStore } from '../../app/stores/store';
import Table from 'react-bootstrap/Table';
import ReplyListItem from './ReplyListItem';
import { Reply } from '../../app/models/reply';
import { useTranslation } from 'react-i18next';

export default observer(function ReplyList() {
    const { t } = useTranslation();
    const { topicId } = useParams<{ topicId: string }>();
    const { replyStore } = useStore();
    const { loading, selectedTopicReplies, loadSelectedTopicReplies } = replyStore;

    useEffect(() => {
        loadSelectedTopicReplies(topicId ?? '');
    }, [topicId, loadSelectedTopicReplies])

    return (
        <Fragment>
            {loading ? (
                <Loading />
            ) : (
                <Table bordered bgcolor='white'>
                    <thead>
                        <tr>
                            <th>{t('replies.title')}</th>
                        </tr>
                    </thead>
                    <tbody>
                        {selectedTopicReplies?.map((reply: Reply) => (
                            <ReplyListItem key={reply.id} reply={reply} />
                        ))}
                    </tbody>
                </Table>
            )}
        </Fragment>
    );
});