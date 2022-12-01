import { observer } from 'mobx-react-lite';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Image from 'react-bootstrap/Image';
import { useParams } from 'react-router-dom';
import { useStore } from '../../app/stores/store';
import { useTranslation } from 'react-i18next';
import { Fragment, useEffect } from 'react';
import Loading from '../../layouts/Loading';

export default observer(function UserDetails() {
    const { t } = useTranslation();
    const { userId } = useParams<{ userId: string }>();
    const { userStore } = useStore();
    const { selectedUser, loadSelectedUser, loadingSelectedUser } = userStore;

    useEffect(() => {
        loadSelectedUser(userId ?? '');
    }, [userId, loadSelectedUser])

    return (
        <Fragment>
            {
                loadingSelectedUser ? (
                    <Loading />
                ) : (
                    <Container className='sf-container'>
                        <Row>
                                <Col>
                                    <Image thumbnail={true} src={selectedUser?.avatar || '/assets/user.png'} height={200} width={200} />
                            </Col>
                            <Col>
                                <h1>{selectedUser?.displayName}</h1>
                                <hr />
                                <span>{selectedUser?.about}</span>
                            </Col>
                        </Row>
                    </Container>
                )
            }
        </Fragment>
    );
});