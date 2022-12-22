import { faEdit } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { FormikProvider, useFormik } from 'formik';
import { observer } from 'mobx-react';
import { Fragment } from 'react';
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Container from 'react-bootstrap/Container';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import { useTranslation } from 'react-i18next';
import { useNavigate } from 'react-router-dom';
import * as Yup from 'yup';
import { Category } from '../../app/models/category';
import { useStore } from '../../app/stores/store';

interface Props {
    category: Category
}

export default observer(function EditCategoryForm({ category }: Props) {
    const { t } = useTranslation();
    const { categoryStore, userStore } = useStore();
    const { edit } = categoryStore;
    const { isAdmin } = userStore;
    const navigate = useNavigate();

    if (!isAdmin) {
        navigate(`/login`);
    }

    const namePlaceholder: string = t('admin.categories.name-ph');
    const descPlaceholder: string = t('admin.categories.desc-ph');

    const checkboxStyle = {
        marginRight: '0.5rem'
    }

    const CategorySchema = Yup.object().shape({
        id: Yup.string().required(),
        name: Yup.string().required(`${t('common.req-field')}`),
        description: Yup.string().default(''),
        displayOrder: Yup.number().default(0),
        isPlaceholder: Yup.boolean().default(false)
    });

    const formik = useFormik({
        initialValues: {
            id: category.id,
            name: category.name,
            description: category.description,
            displayOrder: category.displayOrder,
            isPlaceholder: category.isPlaceholder
        },
        validationSchema: CategorySchema,
        onSubmit: async (values, { resetForm }) => {
            var result = await edit(values);
            if (!result.success) {
                result.errors.forEach((error: string) => {
                    console.log(error);
                });
            }

            resetForm();
        }
    });

    const { errors, touched, handleSubmit, getFieldProps, isSubmitting } = formik;

    return (
        <Fragment>
            <Container className='sf-header sf-bg-colored sf-border-colored sf-text-colored'>
                <FontAwesomeIcon icon={faEdit} /> <strong>{t('admin.categories.edit')}</strong>
            </Container>
            <Container className='sf-container-light mb-0'>
                <FormikProvider value={formik} >
                    <Form onSubmit={handleSubmit}>
                        <Row>
                            <Col xs={12} sm={8}>
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
                            <Col xs={12} sm={4}>
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
                            <Button
                                variant="success"
                                type="submit"
                                className="text-white"
                                disabled={isSubmitting}
                            >
                                {isSubmitting ? t('common.saving') : t('common.save')}
                            </Button>
                        </div>
                    </Form>
                </FormikProvider>
            </Container >
        </Fragment>
    );
});