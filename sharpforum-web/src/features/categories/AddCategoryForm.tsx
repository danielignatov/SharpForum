import { faWandMagicSparkles } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { observer } from 'mobx-react';
import { FormikProvider, useFormik } from 'formik';
import * as Yup from 'yup';
import Form from 'react-bootstrap/Form';
import Container from 'react-bootstrap/Container';
import { useTranslation } from 'react-i18next';
import { useStore } from '../../app/stores/store';
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import { Fragment, useState } from 'react';
import LoginBtn from '../users/LoginBtn';

export default observer(function AddCategoryForm() {
    const { t } = useTranslation();
    const { categoryStore, userStore } = useStore();
    const { add } = categoryStore;
    const [formSubmitted, setFormSubmitted] = useState(false);
    const { isAdmin } = userStore;

    const namePlaceholder: string = t('admin.categories.name-ph');
    const descPlaceholder: string = t('admin.categories.desc-ph');

    const checkboxStyle = {
        marginRight: '0.5rem'
    }

    const CategorySchema = Yup.object().shape({
        name: Yup.string().required(`${t('common.req-field')}`),
        description: Yup.string().default(''),
        displayOrder: Yup.number().default(0),
        isPlaceholder: Yup.boolean().default(false)
    });

    const formik = useFormik({
        initialValues: {
            name: '',
            description: '',
            displayOrder: 0,
            isPlaceholder: false
        },
        validationSchema: CategorySchema,
        onSubmit: async (values) => {
            var result = await add(values);
            if (result.success) {
                setFormSubmitted(true);
            } else {
                result.errors.forEach((error: string) => {
                    console.log(error);
                });

                setFormSubmitted(true);
            }
        }
    });

    const { errors, touched, handleSubmit, getFieldProps } = formik;

    return (
        <Fragment>
            {formSubmitted ? (
                <Fragment />
            ) : (
                <Fragment>
                    <Container className='sf-header sf-bg'>
                        <FontAwesomeIcon icon={faWandMagicSparkles} /> <strong>{t('admin.categories.add')}</strong>
                    </Container>
                    <Container className='sf-container-light mb-0'>
                        {isAdmin ? (
                            <FormikProvider value={formik} >
                                <Form onSubmit={handleSubmit}>
                                    <Row>
                                        <Col xs={6}>
                                            <Form.Group className="mb-3" controlId="formName">
                                                <Form.Label>{t('admin.categories.name')}</Form.Label>
                                                <Form.Control
                                                    type="text"
                                                    placeholder={namePlaceholder}
                                                    {...getFieldProps('name')}
                                                />
                                                {errors.name && touched.name && (
                                                    <p className="text-danger">{errors.name}</p>
                                                )}
                                            </Form.Group>
                                        </Col>
                                        <Col xs={6}>
                                            <Form.Group className="mb-3" controlId="formDisplayOrder">
                                                <Form.Label>{t('admin.categories.displayOrder')}</Form.Label>
                                                <Form.Control
                                                    type="number"
                                                    {...getFieldProps('displayOrder')}
                                                />
                                                {errors.displayOrder && touched.displayOrder && (
                                                    <p className="text-danger">{errors.displayOrder}</p>
                                                )}
                                            </Form.Group>
                                        </Col>
                                    </Row>
                                    <Form.Group className="mb-3" controlId="formDescription">
                                        <Form.Label>{t('admin.categories.desc')}</Form.Label>
                                        <Form.Control
                                            type="text"
                                            placeholder={descPlaceholder}
                                            as="textarea"
                                            rows={2}
                                            {...getFieldProps('description')}
                                        />
                                        {errors.description && touched.description && (
                                            <p className="text-danger">{errors.description}</p>
                                        )}
                                    </Form.Group>
                                    <Form.Group
                                        className="mb-3"
                                        controlId="formIsPlaceholderCheckbox" >
                                        <Form.Check type="checkbox">
                                            <Form.Check.Input
                                                type="checkbox"
                                                style={checkboxStyle}
                                                {...getFieldProps('acceptPrivacyPolicy')}
                                            />
                                            <Form.Label>
                                                {t('admin.categories.placeholder')}
                                            </Form.Label>
                                        </Form.Check>
                                        {errors.isPlaceholder && touched.isPlaceholder && (
                                            <p className="text-danger">{errors.isPlaceholder}</p>
                                        )}
                                    </Form.Group>
                                    <div className="d-grid gap-2">
                                        <Button variant="success" type="submit" className="text-white">
                                            {t('common.publish')}
                                        </Button>
                                    </div>
                                </Form>
                            </FormikProvider>
                        ) : (
                            <Fragment>
                                <Row>
                                    <Col>
                                        <p className='text-center'>{t('replies.add.login-err')}</p>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col>
                                        <div className="d-grid gap-2 mt-2">
                                            <LoginBtn />
                                        </div>
                                    </Col>
                                </Row>
                            </Fragment>
                        )}
                    </Container >
                </Fragment>
            )}
        </Fragment >
    );
});