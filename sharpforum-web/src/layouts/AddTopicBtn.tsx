import { Fragment } from 'react';
import { useTranslation } from 'react-i18next';
import { Link } from 'react-router-dom';

function AddTopicBtn() {
    const { t } = useTranslation();

    return (
        <Fragment>
            <Link
                className="btn btn-success text-white sf-mb-1"
                role="button"
                to="/about"
            >
                {t('topics.add-topic')}
            </Link>
        </Fragment>
    );
}

export default AddTopicBtn;