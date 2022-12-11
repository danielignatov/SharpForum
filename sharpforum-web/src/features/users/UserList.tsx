import Loading from '../../layouts/Loading';
import { useStore } from '../../app/stores/store';
import { Fragment, useEffect } from 'react';
//import { Placeholder } from 'react-bootstrap';
import { observer } from 'mobx-react';
//import { useTranslation } from 'react-i18next';
import Container from 'react-bootstrap/Container';
import UserCard from './UserCard';
import { User } from '../../app/models/user';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

export default observer(function UserList() {
    //const { t } = useTranslation();
    const { userStore } = useStore();
    const { loadingUsers, users, loadUsers } = userStore;

    useEffect(() => {
        loadUsers();
    }, [loadUsers])

    return (
        <Fragment>
            {
                loadingUsers ? (
                    <Loading />
                ) : (
                    <Container className='sf-container'>
                        <Row>
                            {users.map((user: User) => (
                                <Col key={user.id} xs={12} sm={6} md={4} lg={3} xl={2}>
                                    <UserCard user={user} />
                                </Col>
                            ))}
                        </Row>
                    </Container>
                )
            }
        </Fragment>
    );
});