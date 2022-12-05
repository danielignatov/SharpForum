import { observer } from 'mobx-react-lite';
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { useNavigate } from 'react-router-dom';
import { useStore } from '../../app/stores/store';
import { FormikProvider, useFormik } from 'formik';
import * as Yup from 'yup';
import { useState } from 'react';
import { useTranslation } from 'react-i18next';
import PrivacyPolicyLink from '../../layouts/PrivacyPolicyLink';
import Alert from 'react-bootstrap/Alert';

export default observer(function UserRegisterForm() {
    const { t } = useTranslation();
    const { userStore } = useStore();
    const { register } = userStore;
    const navigate = useNavigate();
    //const [showPassword, setShowPassword] = useState(false);
    const [showDisplayNameTakenError, setDisplayNameTakenError] = useState(false);
    const [showEmailTakenError, setEmailTakenError] = useState(false);
    const [showGenericError, setGenericError] = useState(false);

    const namePlaceholder: string = t('users.registerform.name-placeholder');
    const passPlaceholder: string = t('users.registerform.pass-placeholder');
    const emailPlaceholder: string = t('users.registerform.email-placeholder');

    const checkboxStyle = {
        marginRight: '0.5rem'
    }

    const RegisterSchema = Yup.object().shape({
        email: Yup.string().email(`${t('users.registerform.email-invalid-err')}`),
        password: Yup.string().required(`${t('common.req-field')}`),
        displayName: Yup.string().required(`${t('common.req-field')}`),
        acceptPrivacyPolicy: Yup.boolean().required(`${t('users.registerform.privacy-policy-err')}`).oneOf([true], `${t('users.registerform.privacy-policy-err')}`)
    });

    //const handleShowPassword = () => {
    //    setShowPassword((show) => !show);
    //}

    const formik = useFormik({
        initialValues: {
            email: '',
            password: '',
            displayName: '',
            acceptPrivacyPolicy: false
        },
        validationSchema: RegisterSchema,
        onSubmit: async (values) => {
            var result = await register(values);
            if (result.success) {
                navigate('/', { replace: true });
            }
            else {
                debugger;
                result.errors.forEach(error => {
                    switch (error) {
                        case 'User already registered':
                            setDisplayNameTakenError(true);
                            break;
                        case 'User email already registered':
                            setEmailTakenError(true);
                            break;
                        default:
                            setGenericError(true);
                            break;
                    }
                });
            }
        }
    });

    const { errors, touched, setSubmitting, handleSubmit, getFieldProps } = formik;

    return (
        <Container className='sf-container'>
            {showDisplayNameTakenError && (
                <Alert variant='danger'>
                    {t('users.registerform.name-taken-err')}
                </Alert>
            )}
            {showEmailTakenError && (
                <Alert variant='danger'>
                    {t('users.registerform.email-taken-err')}
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
                        <Form.Label>{t('users.registerform.name')}</Form.Label>
                        <Form.Control
                            type="text"
                            placeholder={namePlaceholder}
                            {...getFieldProps('displayName')}
                        />
                        {errors.displayName && touched.displayName && (
                            <p className="text-danger">{errors.displayName}</p>
                        )}
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="formPassword">
                        <Form.Label>{t('users.registerform.password')}</Form.Label>
                        <Form.Control
                            //type={showPassword ? 'text' : 'password'}
                            type='password'
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
                        {errors.password && touched.password && (
                            <p className="text-danger">{errors.password}</p>
                        )}
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="formEmail">
                        <Form.Label>{t('users.registerform.email')}</Form.Label>
                        <Form.Control
                            type="email"
                            placeholder={emailPlaceholder}
                            {...getFieldProps('email')}
                        />
                        {errors.email && touched.email && (
                            <p className="text-danger">{errors.email}</p>
                        )}
                    </Form.Group>

                    <Form.Group
                        className="mb-3"
                        controlId="formPrivacyPolicyCheckbox" >
                        <Form.Check type="checkbox">
                            <Form.Check.Input
                                type="checkbox"
                                style={checkboxStyle}
                                {...getFieldProps('acceptPrivacyPolicy')}
                            />
                            <Form.Label>
                                {t('users.registerform.privacy-policy-notice')}{' '}
                                <PrivacyPolicyLink className='sf-link' />
                            </Form.Label>
                        </Form.Check>
                        {errors.acceptPrivacyPolicy && touched.acceptPrivacyPolicy && (
                            <p className="text-danger">{errors.acceptPrivacyPolicy}</p>
                        )}
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