import { Topic } from '../../app/models/topic';
import Row from 'react-bootstrap/Row';
import { Link } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import Col from 'react-bootstrap/Col';
import ReplyCount from '../replies/ReplyCount';
import Container from 'react-bootstrap/Container';

interface Props {
    topic: Topic
}

function TopicListItem({ topic }: Props) {
    const { t } = useTranslation();
    const topicCreated = new Date(topic?.createdOn ?? '');

    return (
        <Link to={`/topic/${topic.id}`} className='sf-link-no-underline'>
            <Container className='sf-header'>
                <Row>
                    <Col xs={12} sm={12} md={6}>
                        <strong>{topic.subject}</strong>
                    </Col>
                    <Col xs={0} sm={12} md={6}>
                        <small>{t('topics.published')} {t('topics.published-date-time', { date: topicCreated })}</small>
                    </Col>
                </Row>
                <Row>
                    <Col xs={12} sm={12} md={6}>
                        <small>{`${t('common.by')} ${topic.author.displayName}`}</small>
                    </Col>
                    <Col xs={0} sm={12} md={6}>
                        <ReplyCount value={topic.replyCount} />
                    </Col>
                </Row>
            </Container>
        </Link>
    );
}

export default TopicListItem;