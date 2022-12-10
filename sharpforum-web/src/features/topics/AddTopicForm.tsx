import { observer } from 'mobx-react';
import { FormikProvider, useFormik } from 'formik';
import * as Yup from 'yup';
import Form from 'react-bootstrap/Form';
import Container from 'react-bootstrap/Container';
import { useTranslation } from 'react-i18next';
import { useNavigate, useParams } from 'react-router-dom';
import { useStore } from '../../app/stores/store';
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import { Fragment } from 'react';
import LoginBtn from '../users/LoginBtn';

export default observer(function AddTopicForm() {
    const { t } = useTranslation();
    const { categoryId } = useParams<{ categoryId: string }>();
    const { topicStore, userStore } = useStore();
    const { add } = topicStore;
    const { currentUser, isLoggedIn } = userStore;
    const navigate = useNavigate();

    const subjectPlaceholder: string = t('topics.add.subject-placeholder');
    const messagePlaceholder: string = t('topics.add.msg-placeholder');

    const TopicSchema = Yup.object().shape({
        authorId: Yup.string().required(),
        categoryId: Yup.string().required(),
        subject: Yup.string().required(`${t('common.req-field')}`),
        message: Yup.string().required(`${t('common.req-field')}`),
        sticky: Yup.boolean(),
        locked: Yup.boolean(),
    });

    const formik = useFormik({
        initialValues: {
            authorId: currentUser?.id ?? '',
            categoryId: categoryId ?? '',
            subject: '',
            message: '',
            sticky: false,
            locked: false
        },
        validationSchema: TopicSchema,
        onSubmit: async (values) => {
            var result = await add(values);
            if (result.success) {
                navigate(`/topic/${result.topicId}`, { replace: true });
            } else {
                result.errors.forEach((error: string) => {
                    console.log(error);
                });
                navigate('/', { replace: true });
            }
        }
    });

    const { errors, touched, handleSubmit, getFieldProps } = formik;

    return (
        <Container className='sf-container'>
            {isLoggedIn ? (
                <FormikProvider value={formik}>
                    <Form onSubmit={handleSubmit}>
                        <Form.Group className="mb-3" controlId="formSubject">
                            <Form.Label>{t('topics.add.subject')}</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder={subjectPlaceholder}
                                {...getFieldProps('subject')}
                            />
                            {errors.subject && touched.subject && (
                                <p className="text-danger">{errors.subject}</p>
                            )}
                        </Form.Group>

                        <Form.Group className="mb-3" controlId="formMessage">
                            <Form.Label>{t('topics.add.message')}</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder={messagePlaceholder}
                                as="textarea"
                                rows={5}
                                {...getFieldProps('message')}
                            />
                            {errors.message && touched.message && (
                                <p className="text-danger">{errors.message}</p>
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
                            <p className='text-center'>{t('topics.add.login-err')}</p>
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
        </Container>
    );
});