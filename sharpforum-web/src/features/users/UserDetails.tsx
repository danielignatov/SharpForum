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
import robohash from '../../app/utils/robohash';

export default observer(function UserDetails() {
    const { t } = useTranslation();
    const { userId } = useParams<{ userId: string }>();
    const { userStore } = useStore();
    const { selectedUser, loadSelectedUser, loadingSelectedUser } = userStore;
    const { GetKitten } = robohash;

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
                                <Col xs={2}>
                                    <Image thumbnail={true} src={selectedUser?.avatar || GetKitten(selectedUser?.id || '') || '/assets/user.png'} />
                            </Col>
                            <Col xs={10}>
                                <h1>{selectedUser?.displayName}</h1>
                                <hr />
                                <small>{t('users.details.role')}: {selectedUser?.role.name}</small>
                            </Col>
                        </Row>
                    </Container>
                )
            }
        </Fragment>
    );
});