import React, { Fragment } from 'react';
//import { useTranslation } from 'react-i18next';
import { User } from '../../app/models/user';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Image from 'react-bootstrap/Image';
import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCommentAlt } from '@fortawesome/free-solid-svg-icons';

interface Props {
    user: User
}

function UserInfo({ user }: Props) {
    //const { t } = useTranslation();

    return (
        <Fragment>
            <Row>
                <Col>
                    <Link
                        to={`/user/${user.id}`}
                        className='sf-link-no-underline'>
                        <div className='text-center'>
                            <strong>{user.displayName}</strong>
                        </div>
                    </Link>
                </Col>
            </Row>
            <Row>
                <Col>
                    <div className='text-center pb-1'>
                        <small>{user.role.name}</small>
                    </div>
                </Col>
            </Row>
            <Row>
                <Col>
                    <Image thumbnail={true} src={user.avatar || '/assets/user.png'} />
                </Col>
            </Row>
            <Row>
                <Col>
                    <div className='text-center pb-1'>
                        <FontAwesomeIcon icon={faCommentAlt} size="sm" className="mt-3" /> <small>1337</small>
                    </div>
                </Col>
            </Row>
        </Fragment>
    );
}

export default UserInfo;