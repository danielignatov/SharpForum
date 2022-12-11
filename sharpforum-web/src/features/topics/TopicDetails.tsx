import { observer } from 'mobx-react';
import React, { Fragment, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Loading from '../../layouts/Loading';
import { useStore } from '../../app/stores/store';
import Table from 'react-bootstrap/Table';
import Row from 'react-bootstrap/Row';
import ReplyList from '../replies/ReplyList';
import { useTranslation } from 'react-i18next';
import AddReplyForm from '../replies/AddReplyForm';
import Col from 'react-bootstrap/Col';
import Image from 'react-bootstrap/Image';

export default observer(function TopicDetails() {
    const { t } = useTranslation();
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
                    <Table bordered bgcolor='white'>
                        <thead>
                            <tr>
                                <th>{t('topics.singular')}</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <Row>
                                        <Col xs={6} sm={2} md={2} lg={2}>
                                            <Image thumbnail={true} src={selectedTopic?.author?.avatar || '/assets/user.png'} />
                                        </Col>
                                        <Col xs={6} sm={10} md={10} lg={10}>
                                            <Row>
                                                <strong>{selectedTopic?.subject}</strong>
                                            </Row>
                                            <Row>
                                                <small>{selectedTopic?.message}</small>
                                            </Row>
                                            <Row>
                                                <small>{t('common.by')} {selectedTopic?.author.displayName}</small>
                                            </Row>
                                        </Col>
                                    </Row>

                                </td>
                            </tr>
                        </tbody>
                    </Table>
                    <ReplyList />
                    <AddReplyForm topicId={topicId ?? ''} />
                </Fragment>
            )}
        </Fragment>
    );
});