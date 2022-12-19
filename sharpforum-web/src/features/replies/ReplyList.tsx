import { observer } from 'mobx-react';
import { Fragment, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Loading from '../../layouts/Loading';
import { useStore } from '../../app/stores/store';
import ReplyListItem from './ReplyListItem';
import { Reply } from '../../app/models/reply';
import { useTranslation } from 'react-i18next';
import Heading from '../../layouts/Heading';

export default observer(function ReplyList() {
    const { t } = useTranslation();
    const { topicId } = useParams<{ topicId: string }>();
    const { replyStore } = useStore();
    const { loading, selectedTopicReplies, loadSelectedTopicReplies } = replyStore;
    const noReplies = selectedTopicReplies?.length === 0;
    const noRepliesText = t('replies.none') ?? '';

    useEffect(() => {
        loadSelectedTopicReplies(topicId ?? '');
    }, [topicId, loadSelectedTopicReplies])

    return (
        <Fragment>
            <Heading
                title={t('replies.title')}
                subtitle={noReplies ? noRepliesText : ''}
                colored={true} />
            {loading ? (
                <Loading />
            ) : (
                <div className={!noReplies ? 'mb-3' : ''}>
                    {selectedTopicReplies?.map((reply: Reply) => (
                        <ReplyListItem key={reply.id} reply={reply} />
                    ))}
                </div>
            )}
        </Fragment>
    );
});