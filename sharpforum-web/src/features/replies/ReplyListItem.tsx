import React, { Fragment } from 'react';
import { Reply } from '../../app/models/reply';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Link } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import UserInfo from '../users/UserInfo';
import { User } from '../../app/models/user';

interface Props {
    reply: Reply
}

function ReplyListItem({ reply }: Props) {
    const { t } = useTranslation();

    return (
        <Fragment>
            <tr>
                <td>
                    <Row>
                        <Col xs={6} sm={2} md={2} lg={2}>
                            <UserInfo user={reply?.author ?? new User()} />
                        </Col>
                        <Col xs={6} sm={10} md={10} lg={10}>
                            <Row>
                                <span>{reply.message}</span>
                            </Row>
                            <Row>
                                <small>{t('common.by')} <Link to={`/user/${reply.authorId}`} className='sf-link'>{reply.author.displayName}</Link></small>
                            </Row>
                        </Col>
                    </Row>
                    
                </td>
            </tr>
        </Fragment>
    );
}

export default ReplyListItem;