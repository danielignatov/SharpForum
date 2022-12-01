import React, { Fragment } from 'react';
import { Reply } from '../../app/models/reply';
import Row from 'react-bootstrap/Row';
import { Link } from 'react-router-dom';
import { useTranslation } from 'react-i18next';

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
                        <span>{reply.message}</span>
                    </Row>
                    <Row>
                        <small>{t('common.by')} <Link to={`/user/${reply.authorId}`} className='sf-link'>{reply.author.displayName}</Link></small>
                    </Row>
                </td>
            </tr>
        </Fragment>
    );
}

export default ReplyListItem;