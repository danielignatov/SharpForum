import { observer } from 'mobx-react';
import { FormikProvider, useFormik } from 'formik';
import * as Yup from 'yup';
import Form from 'react-bootstrap/Form';
import Container from 'react-bootstrap/Container';
import { useTranslation } from 'react-i18next';
//import { useNavigate, useParams } from 'react-router-dom';
import { useStore } from '../../app/stores/store';
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import { Fragment, useState } from 'react';
import LoginBtn from '../users/LoginBtn';

interface Props {
    topicId: string
}

export default observer(function AddReplyForm({ topicId }: Props) {
    const { t } = useTranslation();
    const { replyStore, userStore } = useStore();
    const { add } = replyStore;
    const [formSubmitted, setFormSubmitted] = useState(false);
    const { currentUser, isLoggedIn } = userStore;
    //const navigate = useNavigate();

    const messagePlaceholder: string = t('replies.add.msg-placeholder');

    const ReplySchema = Yup.object().shape({
        authorId: Yup.string().required(),
        topicId: Yup.string().required(),
        message: Yup.string().required(`${t('common.req-field')}`)
    });

    const formik = useFormik({
        initialValues: {
            authorId: currentUser?.id ?? '',
            topicId: topicId ?? '',
            message: ''
        },
        validationSchema: ReplySchema,
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
                <Container className='sf-container'>
                    {isLoggedIn ? (
                        <FormikProvider value={formik} >
                            <Form onSubmit={handleSubmit}>
                                <Form.Group className="mb-3" controlId="formMessage">
                                    <Form.Label>{t('replies.add.message')}</Form.Label>
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
            )}
        </Fragment>
    );
});