import { Link, useNavigate } from 'react-router-dom';
import { observer } from 'mobx-react-lite';
import { useStore } from '../../app/stores/store';
import { useTranslation } from 'react-i18next';
import { FormikProvider, useFormik } from 'formik';
import * as Yup from 'yup';
import Button from 'react-bootstrap/Button';
import Container from 'react-bootstrap/Container';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import { useState } from 'react';
import Alert from 'react-bootstrap/Alert';
import InputGroup from 'react-bootstrap/InputGroup';

export default observer(function UserLoginForm() {
    const { t } = useTranslation();
    const { userStore } = useStore();
    const { login } = userStore;
    const navigate = useNavigate();
    const [showPassword, setShowPassword] = useState(false);
    const [showDisplayNameError, setDisplayNameError] = useState(false);
    const [showPasswordError, setPasswordError] = useState(false);
    const [showGenericError, setGenericError] = useState(false);
    const namePlaceholder: string = t('users.loginform.name-placeholder');
    const passPlaceholder: string = t('users.loginform.pass-placeholder');

    const LoginSchema = Yup.object().shape({
        displayName: Yup.string().required(`${t('common.req-field')}`),
        password: Yup.string().required(`${t('common.req-field')}`)
    });

    const handleShowPassword = () => {
        setShowPassword((showPassword) => !showPassword);
    }

    const formik = useFormik({
        initialValues: {
            displayName: '',
            password: ''
        },
        validationSchema: LoginSchema,
        onSubmit: async (values) => {
            var result = await login(values);
            if (result.success) {
                navigate('/', { replace: true });
            } else {
                result.errors.forEach(error => {
                    switch (error) {
                        case 'User not found':
                            setDisplayNameError(true);
                            break;
                        case 'Unauthorized':
                            setPasswordError(true);
                            break;
                        default:
                            setGenericError(true);
                            break;
                    }
                });
            }
        }
    });

    const { errors, touched, handleSubmit, getFieldProps } = formik;

    return (
        <Container className='sf-container'>
            {showDisplayNameError && (
                <Alert variant='danger'>
                    {t('users.loginform.name-err')}
                </Alert>
            )}
            {showPasswordError && (
                <Alert variant='danger'>
                    {t('users.loginform.pass-err')}
                </Alert>
            )}
            {showGenericError && (
                <Alert variant='danger'>
                    {t('common.err')}
                </Alert>
            )}
            <FormikProvider value={formik}>
                <Form onSubmit={handleSubmit}>
                    <Form.Group className="mb-3" controlId="formDisplayName">
                        <Form.Label>{t('users.loginform.name')}</Form.Label>
                        <Form.Control
                            type="text"
                            placeholder={namePlaceholder}
                            {...getFieldProps('displayName')}
                        />
                        {errors.displayName && touched.displayName && (
                            <p className="text-danger">{errors.displayName}</p>
                        )}
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="formBasicPassword">
                        <Form.Label>{t('users.loginform.password')}</Form.Label>
                        <InputGroup>
                            <Form.Control
                                type={showPassword ? 'text' : 'password'}
                                placeholder={passPlaceholder}
                                {...getFieldProps('password')}
                            />
                            <Button variant="outline-secondary" onClick={handleShowPassword}>
                                {showPassword ? t('common.hide') : t('common.show')}
                            </Button>
                        </InputGroup>
                        {errors.password && touched.password && (
                            <p className="text-danger">{errors.password}</p>
                        )}
                    </Form.Group>

                    <Row>
                        <small className="text-center">
                            {t('users.loginform.no-account-q')} <Link to='/register' className='sf-link'>{t('common.register')}</Link>
                        </small>
                    </Row>

                    <div className="d-grid gap-2 mt-2">
                        <Button variant="success" type="submit" className="text-white">
                            {t('common.login')}
                        </Button>
                    </div>
                </Form>
            </FormikProvider>
        </Container>
    );
});