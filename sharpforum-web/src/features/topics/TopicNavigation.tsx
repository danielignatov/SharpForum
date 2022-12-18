import { faChevronRight, faHouseChimney } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Fragment } from 'react';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import { useTranslation } from 'react-i18next';
import { Link } from 'react-router-dom';
import { Topic } from '../../app/models/topic';
import ReplyCount from '../replies/ReplyCount';

interface Props {
    topic: Topic
}

function TopicNavigation({ topic }: Props) {
    const { t } = useTranslation();
    const topicCreated = new Date(topic?.createdOn ?? '');

    return (
        <Fragment>
            <Row>
                <Col xs={12} md={6}>
                    <small>
                        <FontAwesomeIcon icon={faHouseChimney} size="sm" /> <Link to={`/`} className='sf-link-no-underline'>{t('layout.nav.home')}</Link>
                        <FontAwesomeIcon icon={faChevronRight} size="sm" /> <Link to={`/category/${topic.categoryId}`} className='sf-link-no-underline'>{topic.category?.name}</Link>
                        <FontAwesomeIcon icon={faChevronRight} size="sm" /> <Link to={`/topic/${topic.id}`} className='sf-link-no-underline'>{topic.subject}</Link>
                    </small>
                </Col>
                <Col xs={12} md={6}>
                    <div className='text-end'>
                        <small>{t('topics.published')} {t('topics.published-date', { date: topicCreated })} {t('common.by')} {' '}
                            <Link
                                to={`/user/${topic.authorId}`}
                                className='sf-link-no-underline'>{topic.author.displayName}
                            </Link>, {' '}
                        </small><ReplyCount value={topic.replyCount ?? 0} />
                    </div>
                </Col>
            </Row>
        </Fragment>
    );
}

export default TopicNavigation;