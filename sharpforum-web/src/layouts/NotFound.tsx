import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faFaceGrinBeamSweat } from '@fortawesome/free-regular-svg-icons';
import Container from 'react-bootstrap/Container';
import { useTranslation } from 'react-i18next';
import { Link } from 'react-router-dom';

function NotFound() {
    const { t } = useTranslation();

    return (
        <Container className='sf-container'>
            <div className="text-center">
                <FontAwesomeIcon icon={faFaceGrinBeamSweat} size="6x" className="mt-3" />
                <p className="fs-3"> <span className="text-primary">{t('layout.notfound.yikes')}</span> {t('layout.notfound.info')}</p>
                <Link
                    className="btn btn-primary text-white sf-mb-1"
                    role="button"
                    to={`/`}
                >
                    {t('layout.notfound.link')}
                </Link>
            </div>
        </Container>
    );
}

export default NotFound;