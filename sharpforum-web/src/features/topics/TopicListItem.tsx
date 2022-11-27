import React, { Fragment } from 'react';
import { Topic } from '../../app/models/topic';
import Row from 'react-bootstrap/Row';
import { Link } from 'react-router-dom';

interface Props {
    topic: Topic
}

function TopicListItem({ topic }: Props) {
    return (
        <Fragment>
            <tr>
                <td>
                    <Row>
                        <Link to={`/topic/${topic.id}`} className='sf-link'>
                            <strong>{topic.subject}</strong>
                        </Link>
                    </Row>
                    <Row>
                        <small>by <Link to={`/user/${topic.authorId}`} className='sf-link'>{topic.author.displayName}</Link></small>
                    </Row>
                </td>
            </tr>
        </Fragment>
    );
}

export default TopicListItem;