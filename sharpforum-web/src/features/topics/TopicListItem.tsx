import React, { Fragment } from 'react';
import { Topic } from '../../app/models/topic';
import Row from 'react-bootstrap/Row';

interface Props {
    topic: Topic
}

function TopicListItem({ topic }: Props) {
    return (
        <Fragment>
            <tr>
                <td>
                    <Row>
                        <strong>{topic.subject}</strong>
                    </Row>
                    <Row>
                        <small>by {topic.author.displayName}</small>
                    </Row>
                </td>
            </tr>
        </Fragment>
    );
}

export default TopicListItem;