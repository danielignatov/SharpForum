import React, { Fragment } from 'react';
import { Topic } from '../../app/models/topic';
import Row from 'react-bootstrap/Row';
import { Link } from 'react-router-dom';
import { useTranslation } from 'react-i18next';

interface Props {
    topic: Topic
}

function TopicListItem({ topic }: Props) {
    const { t } = useTranslation();

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
                        <small>{t('common.by')} <Link to={`/user/${topic.authorId}`} className='sf-link'>{topic.author.displayName}</Link></small>
                    </Row>
                </td>
            </tr>
        </Fragment>
    );
}

export default TopicListItem;