import { observer } from 'mobx-react-lite';
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { useNavigate } from 'react-router-dom';
import { useStore } from '../../app/stores/store';

export default observer(function UserRegisterForm() {
    const { userStore } = useStore();
    const { register } = userStore;
    const navigate = useNavigate();

    const handleSubmit = (event: any) => {
        event.preventDefault();

        register({
            displayName: event.target[0].value,
            password: event.target[1].value
        });

        navigate('/', { replace: true });
    }

    return (
        <Container className='sf-container'>
            <Form onSubmit={handleSubmit}>
                <Form.Group className="mb-3" controlId="formDisplayName">
                    <Form.Label>Name</Form.Label>
                    <Form.Control type="text" placeholder="Enter display name" />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>Password</Form.Label>
                    <Form.Control type="password" placeholder="Password" />
                </Form.Group>

                <Button variant="success" type="submit">
                    Register
                </Button>
            </Form>
        </Container>
    );
});