import { observer } from 'mobx-react-lite';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { Link, useNavigate } from 'react-router-dom';
import { useStore } from '../../app/stores/store';
import { useTranslation } from 'react-i18next';

export default observer(function UserLoginForm() {
    const { t } = useTranslation();
    const { userStore } = useStore();
    const { login } = userStore;
    const navigate = useNavigate();
    const namePlaceholder: string = t('users.loginform.name-placeholder');
    const passPlaceholder: string = t('users.loginform.pass-placeholder');

    const handleSubmit = (event: any) => {
        event.preventDefault();

        login({
            displayName: event.target[0].value,
            password: event.target[1].value
        });

        navigate('/', { replace: true });
    }

    return (
        <Container className='sf-container'>
            <Form onSubmit={handleSubmit}>
                <Form.Group className="mb-3" controlId="formDisplayName">
                    <Form.Label>{t('users.loginform.name')}</Form.Label>
                    <Form.Control type="text" placeholder={namePlaceholder} />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>{t('users.loginform.password')}</Form.Label>
                    <Form.Control type="password" placeholder={passPlaceholder} />
                </Form.Group>

                <Row>
                    <small className="text-center">
                        {t('users.loginform.no-account-q')} <Link to='/register' className='sf-link'>{t('common.register')}</Link>
                    </small>
                </Row>
                <div className="d-grid gap-2 mt-2">
                    <Button variant="success" type="submit">
                        {t('common.login')}
                    </Button>
                </div>
            </Form>
        </Container>
    );
});