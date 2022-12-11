import Card from 'react-bootstrap/Card';
import { useTranslation } from 'react-i18next';
import { Link } from 'react-router-dom';
import { User } from '../../app/models/user';

interface Props {
    user: User
}

function UserCard({ user }: Props) {
    const { t } = useTranslation();

    return (
        <Card>
            <Card.Img variant="top" src={user.avatar} />
            <Card.Body>
                <Card.Title>{user.displayName}</Card.Title>
                <Card.Text>
                    {user.role.name}
                </Card.Text>
                <div className="d-grid gap-2">
                    <Link
                        className="btn btn-primary btn-full text-white sf-mb-1"
                        role="button"
                        to={`/user/${user.id}`}
                    >
                        {t('common.profile')}
                    </Link>
                </div>
            </Card.Body>
        </Card>
    );
}

export default UserCard;