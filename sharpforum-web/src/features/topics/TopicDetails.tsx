import { observer } from 'mobx-react';
import { Fragment, useEffect } from 'react';
import { Link, useParams } from 'react-router-dom';
import Loading from '../../layouts/Loading';
import { useStore } from '../../app/stores/store';
import Table from 'react-bootstrap/Table';
import Row from 'react-bootstrap/Row';
import ReplyList from '../replies/ReplyList';
import { useTranslation } from 'react-i18next';
import AddReplyForm from '../replies/AddReplyForm';
import Col from 'react-bootstrap/Col';
import Container from 'react-bootstrap/Container';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faChevronRight, faCommentAlt, faHouseChimney } from '@fortawesome/free-solid-svg-icons';
import ReplyCount from '../replies/ReplyCount';
import UserInfo from '../users/UserInfo';
import { User } from '../../app/models/user';

export default observer(function TopicDetails() {
    const { t } = useTranslation();
    const { topicId } = useParams<{ topicId: string }>();
    const { topicStore } = useStore();
    const { loading, selectedTopic, loadSelectedTopic } = topicStore;
    //const topicCreated = new Date(selectedTopic?.createdOn ?? '');

    useEffect(() => {
        loadSelectedTopic(topicId ?? '');
    }, [topicId, loadSelectedTopic])

    return (
        <Fragment>
            {loading ? (
                <Loading />
            ) : (
                <Fragment>
                    <Container className='sf-header'>
                        <Row>
                            <strong>{t('topics.singular')}</strong>
                        </Row>
                    </Container>
                    <Table bordered bgcolor='white'>
                        <tbody>
                            <tr>
                                <td>
                                    <Row>
                                        <Col xs={6} sm={2} md={2} lg={2}>
                                            <UserInfo user={selectedTopic?.author ?? new User()} />
                                        </Col>
                                        <Col xs={6} sm={10} md={10} lg={10}>
                                            <Row>
                                                <Col>
                                                    <small>
                                                        <FontAwesomeIcon icon={faHouseChimney} size="sm" /> <Link to={`/`} className='sf-link-no-underline'>{t('layout.nav.home')}</Link>
                                                        <FontAwesomeIcon icon={faChevronRight} size="sm" /> <Link to={`/category/${selectedTopic?.categoryId}`} className='sf-link-no-underline'>{selectedTopic?.category?.name}</Link>
                                                        <FontAwesomeIcon icon={faChevronRight} size="sm" /> <Link to={`/topic/${selectedTopic?.id}`} className='sf-link-no-underline'>{selectedTopic?.subject}</Link>
                                                    </small>
                                                </Col>
                                                <Col>
                                                    <div className='text-end'>
                                                        <small>{t('topics.published')} 1.3.37 {t('common.by')} {' '}
                                                            <Link
                                                                to={`/user/${selectedTopic?.authorId}`}
                                                                className='sf-link-no-underline'>{selectedTopic?.author.displayName}
                                                            </Link>, {' '}
                                                        </small><ReplyCount value={selectedTopic?.replyCount ?? 0} />
                                                    </div>
                                                </Col>
                                            </Row>
                                            <Row>
                                                <Col>
                                                    <h1>{selectedTopic?.subject}</h1>
                                                    <hr />
                                                </Col>
                                            </Row>
                                            <Row>
                                                <Col>
                                                    <p>{selectedTopic?.message}</p>
                                                </Col>
                                            </Row>
                                            {selectedTopic?.author?.signature &&
                                                <Row>
                                                    <Col>
                                                        <hr />
                                                        <span>{selectedTopic?.author?.signature}</span>
                                                    </Col>
                                                </Row>
                                            }
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