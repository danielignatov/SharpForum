//import { faLink } from '@fortawesome/free-solid-svg-icons';
//import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Fragment } from 'react';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import { useTranslation } from 'react-i18next';
import { Link } from 'react-router-dom';
import { Reply } from '../../app/models/reply';

interface Props {
    reply: Reply,
}

function ReplyNavigation({ reply }: Props) {
    const { t } = useTranslation();
    const replyCreated = new Date(reply.createdOn);

    return (
        <Fragment>
            <Row id={`reply-${reply.id}`}>
                <Col xs={12} md={6}>
                    {/*<small>*/}
                    {/*    <FontAwesomeIcon icon={faLink} size="sm" /> <a href={`/topic/${reply.topicId}#reply-${reply.id}`} className='sf-link-no-underline'>{t('replies.anchor')}</a>*/}
                    {/*</small>*/}
                </Col>
                <Col xs={12} md={6}>
                    <div className='text-end'>
                        <small>{t('replies.replied')} {t('topics.published-date', { date: replyCreated })} {t('common.by')} {' '}
                            <Link
                                to={`/user/${reply.authorId}`}
                                className='sf-link-no-underline'>{reply.author.displayName}
                            </Link>
                        </small>
                    </div>
                </Col>
            </Row>
        </Fragment>
    );
}

export default ReplyNavigation;