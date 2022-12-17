import React, { Fragment } from 'react';
import { Topic } from '../../app/models/topic';
import Row from 'react-bootstrap/Row';
import { Link } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import Col from 'react-bootstrap/Col';
import ReplyCount from '../replies/ReplyCount';

interface Props {
    topic: Topic
}

function TopicListItem({ topic }: Props) {
    const { t } = useTranslation();
    const topicCreated = new Date(topic?.createdOn ?? '');

    return (
        <Fragment>
            <tr>
                <td>
                    <Row>
                        <Col xs={12} sm={12} md={6}>
                            <Link to={`/topic/${topic.id}`} className='sf-link'>
                                <strong>{topic.subject}</strong>
                            </Link>
                        </Col>
                        <Col xs={0} sm={12} md={6}>
                            <small>{t('topics.published')} {t('topics.published-date', { date: topicCreated })}</small>
                        </Col>
                    </Row>
                    <Row>
                        <Col xs={12} sm={12} md={6}>
                            <small>{t('common.by')} <Link to={`/user/${topic.authorId}`} className='sf-link'>{topic.author.displayName}</Link></small>
                        </Col>
                        <Col xs={0} sm={12} md={6}>
                            <ReplyCount value={topic.replyCount} />
                        </Col>
                    </Row>
                </td>
            </tr>
        </Fragment>
    );
}

export default TopicListItem;