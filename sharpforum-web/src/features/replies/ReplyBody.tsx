import { Fragment } from 'react';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import { Reply } from '../../app/models/reply';
import UserInfo from '../users/UserInfo';
import ReplyNavigation from './ReplyNavigation';

interface Props {
    reply: Reply
}

function ReplyBody({ reply }: Props) {
    return (
        <Fragment>
            <Row>
                <Col xs={4} sm={2} md={2} lg={2}>
                    <UserInfo user={reply.author} />
                </Col>
                <Col xs={8} sm={10} md={10} lg={10}>
                    <ReplyNavigation reply={reply} />
                    <Row>
                        <Col>
                            <p>{reply.message}</p>
                        </Col>
                    </Row>
                    {reply.author?.signature &&
                        <Row>
                            <Col>
                                <hr />
                                <span>{reply.author?.signature}</span>
                            </Col>
                        </Row>
                    }
                </Col>
            </Row>
        </Fragment>
    );
}

export default ReplyBody;