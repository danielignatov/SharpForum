import { Fragment } from 'react';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import { Topic } from '../../app/models/topic';
import UserInfo from '../users/UserInfo';
import TopicNavigation from './TopicNavigation';

interface Props {
    topic: Topic
}

function TopicBody({ topic }: Props) {
    return (
        <Fragment>
            <Row>
                <Col xs={4} sm={2} md={2} lg={2}>
                    <UserInfo user={topic.author} />
                </Col>
                <Col xs={8} sm={10} md={10} lg={10}>
                    <TopicNavigation topic={topic} />
                    <Row>
                        <Col>
                            <h1>{topic.subject}</h1>
                            <hr />
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                            <p>{topic.message}</p>
                        </Col>
                    </Row>
                    {topic.author?.signature &&
                        <Row>
                            <Col>
                                <hr />
                                <span>{topic.author?.signature}</span>
                            </Col>
                        </Row>
                    }
                </Col>
            </Row>
        </Fragment>
    );
}

export default TopicBody;