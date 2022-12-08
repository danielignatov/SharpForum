import { Fragment } from 'react';
import { useTranslation } from 'react-i18next';
import { Link } from 'react-router-dom';

function AddReplyBtn() {
    const { t } = useTranslation();

    return (
        <Fragment>
            <Link
                className="btn btn-success text-white sf-mb-1"
                role="button"
                to="/about"
            >
                {t('replies.add-reply')}
            </Link>
        </Fragment>
    );
}

export default AddReplyBtn;