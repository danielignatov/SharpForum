import Table from 'react-bootstrap/Table';
import { Topic } from '../../app/models/topic';
import TopicListItem from './TopicListItem';
import { useTranslation } from 'react-i18next';

interface Props {
    topics: Topic[]
}

export default function TopicList({ topics }: Props) {
    const { t } = useTranslation();

    return (
        <Table bordered bgcolor='white'>
            <thead>
                <tr>
                    <th>{t('topics.title')}</th>
                </tr>
            </thead>
            <tbody>
                {topics?.map((topic: Topic) => (
                    <TopicListItem key={topic.id} topic={topic} />
                ))}
            </tbody>
        </Table>
    );
}