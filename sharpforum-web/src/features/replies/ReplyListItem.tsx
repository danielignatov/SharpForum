import React, { Fragment } from 'react';
import { Reply } from '../../app/models/reply';
import Row from 'react-bootstrap/Row';
import { Link } from 'react-router-dom';

interface Props {
    reply: Reply
}

function ReplyListItem({ reply }: Props) {
    return (
        <Fragment>
            <tr>
                <td>
                    <Row>
                        <span>{reply.message}</span>
                    </Row>
                    <Row>
                        <small>by <Link to={`/user/${reply.authorId}`} className='sf-link'>{reply.author.displayName}</Link></small>
                    </Row>
                </td>
            </tr>
        </Fragment>
    );
}

export default ReplyListItem;