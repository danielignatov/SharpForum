import { useTranslation } from 'react-i18next';
import { Link } from 'react-router-dom';

interface Props {
    className?: string
}

function PrivacyPolicyLink({ className }: Props) {
    const { t } = useTranslation();

    return (
        <Link to='/privacy' target='_blank' className={className} >
            {t('privacy.title')}
        </Link>
    );
}

export default PrivacyPolicyLink;