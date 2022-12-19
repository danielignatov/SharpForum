import { Topic } from '../../app/models/topic';
import TopicListItem from './TopicListItem';
import { useTranslation } from 'react-i18next';
import { Fragment } from 'react';
import Heading from '../../layouts/Heading';

interface Props {
    topics: Topic[]
}

export default function TopicList({ topics }: Props) {
    const { t } = useTranslation();

    return (
        <Fragment>
            <Heading title={t('topics.title')} colored={false} />
            <div className='pb-3'>
                {topics?.map((topic: Topic) => (
                    <TopicListItem key={topic.id} topic={topic} />
                ))}
            </div>
        </Fragment>
    );
}