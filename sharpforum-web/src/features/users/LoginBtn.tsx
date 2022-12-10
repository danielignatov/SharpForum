import { Fragment } from 'react';
import { useTranslation } from 'react-i18next';
import { Link } from 'react-router-dom';

function LoginBtn() {
    const { t } = useTranslation();

    return (
        <Fragment>
            <Link
                className="btn btn-primary text-white"
                role="button"
                to={`/login`}
            >
                {t('common.login')}
            </Link>
        </Fragment>
    );
}

export default LoginBtn;