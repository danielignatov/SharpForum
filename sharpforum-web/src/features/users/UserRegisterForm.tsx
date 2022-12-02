import { observer } from 'mobx-react-lite';
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { Link, useNavigate } from 'react-router-dom';
import { useStore } from '../../app/stores/store';
import { FormikProvider, useFormik } from 'formik';
import * as Yup from 'yup';
import { useState } from 'react';
import { useTranslation } from 'react-i18next';
import PrivacyPolicyLink from '../../layouts/PrivacyPolicyLink';

export default observer(function UserRegisterForm() {
    const { t } = useTranslation();
    const { userStore } = useStore();
    const { register } = userStore;
    const navigate = useNavigate();
    const [showPassword, setShowPassword] = useState(false);
    const namePlaceholder: string = t('users.registerform.name-placeholder');
    const passPlaceholder: string = t('users.registerform.pass-placeholder');
    const emailPlaceholder: string = t('users.registerform.email-placeholder');
    const privacyPolicyNotice: string = t('users.registerform.privacy-policy-notice');

    const checkboxStyle = {
        marginRight: '0.5rem'
    }

    const RegisterSchema = Yup.object().shape({
        email: Yup.string().email('Email must be a valid email address'),
        password: Yup.string().required('Password is required'),
        displayName: Yup.string().required('Display name is required')
    });

    const handleShowPassword = () => {
        setShowPassword((show) => !show);
    }

    const formik = useFormik({
        initialValues: {
            email: '',
            password: '',
            displayName: '',
        },
        validationSchema: RegisterSchema,
        onSubmit: values => {
            register(values);

            navigate('/', { replace: true });
        },
    });

    const { errors, touched, values, isSubmitting, setSubmitting, handleSubmit, getFieldProps } = formik;

    return (
        <Container className='sf-container'>
            <FormikProvider value={formik}>
                <Form onSubmit={handleSubmit}>
                    <Form.Group className="mb-3" controlId="formDisplayName">
                        <Form.Label>{t('users.registerform.name')}</Form.Label>
                        <Form.Control
                            type="text"
                            placeholder={namePlaceholder}
                            {...getFieldProps('displayName')}
                        />
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="formPassword">
                        <Form.Label>{t('users.registerform.password')}</Form.Label>
                        <Form.Control
                            type={showPassword ? 'text' : 'password'}
                            placeholder={passPlaceholder}
                            //InputProps={{
                            //    endAdornment: (
                            //        <InputAdornment position="end">
                            //            <IconButton onClick={handleShowPassword} edge="end">
                            //                <Icon icon={showPassword ? VisibilityIcon : VisibilityOffIcon} />
                            //            </IconButton>
                            //        </InputAdornment>
                            //    )
                            //}}
                            {...getFieldProps('password')}
                        />
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="formEmail">
                        <Form.Label>{t('users.registerform.email')}</Form.Label>
                        <Form.Control
                            type="email"
                            placeholder={emailPlaceholder}
                            {...getFieldProps('email')}
                        />
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="formPrivacyPolicyCheckbox">
                        <Form.Check type="checkbox">
                            <Form.Check.Input type="checkbox" style={checkboxStyle} />
                            <Form.Label>
                                {t('users.registerform.privacy-policy-notice')}{' '}
                                <PrivacyPolicyLink className='sf-link' />
                            </Form.Label>
                        </Form.Check>
                    </Form.Group>

                    <div className="d-grid gap-2">
                        <Button variant="success" type="submit">
                            {t('common.register')}
                        </Button>
                    </div>
                </Form>
            </FormikProvider>
        </Container>
    );
});