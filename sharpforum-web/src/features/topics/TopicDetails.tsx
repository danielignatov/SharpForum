import { observer } from 'mobx-react';
import React, { Fragment, useEffect } from 'react';
import Button from 'react-bootstrap/Button';
import { useParams } from 'react-router-dom';
import Loading from '../../layouts/Loading';
import { useStore } from '../../app/stores/store';
import Table from 'react-bootstrap/Table';
import Row from 'react-bootstrap/Row';
import ReplyList from '../replies/ReplyList';

export default observer(function TopicDetails() {
    const { topicId } = useParams<{ topicId: string }>();
    const { topicStore } = useStore();
    const { loading, selectedTopic, loadSelectedTopic } = topicStore;

    useEffect(() => {
        loadSelectedTopic(topicId ?? '');
    }, [topicId, loadSelectedTopic])

    return (
        <Fragment>
            {loading ? (
                <Loading />
            ) : (
                <Fragment>
                    <Button variant='success' className='sf-mb-1'>Add Reply</Button>
                    <Table bordered bgcolor='white'>
                        <thead>
                            <tr>
                                <th>Topic</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <Row>
                                        <strong>{selectedTopic?.subject}</strong>
                                    </Row>
                                    <Row>
                                        <small>{selectedTopic?.message}</small>
                                    </Row>
                                    <Row>
                                        <small>by {selectedTopic?.author.displayName}</small>
                                    </Row>
                                </td>
                            </tr>
                        </tbody>
                    </Table>
                    <ReplyList />
                    <Button variant='success' className='sf-mb-1'>Add Reply</Button>
                </Fragment>
            )}
        </Fragment>
    );
});