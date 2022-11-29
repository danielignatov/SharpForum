//import { ErrorMessage, Form, Formik } from 'formik';
import { observer } from 'mobx-react-lite';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { useNavigate } from 'react-router-dom';
import { useStore } from '../../app/stores/store';

export default observer(function UserLoginForm() {
    const { userStore } = useStore();
    const { login } = userStore;
    const navigate = useNavigate();

    const handleSubmit = (event: any) => {
        event.preventDefault();
        login({ displayName: event.target[0].value, password: event.target[1].value });

        navigate('/', { replace: true });
    }

    return (
        <Form onSubmit={handleSubmit}>
            <Form.Group className="mb-3" controlId="formDisplayName">
                <Form.Label>Name</Form.Label>
                <Form.Control type="text" placeholder="Enter display name" />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicPassword">
                <Form.Label>Password</Form.Label>
                <Form.Control type="password" placeholder="Password" />
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicCheckbox">
                <Form.Check type="checkbox" label="Check me out" />
            </Form.Group>
            <Button variant="primary" type="submit">
                Submit
            </Button>
        </Form>
    );
});