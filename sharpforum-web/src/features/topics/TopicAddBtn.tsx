import { Fragment } from 'react';
import { useTranslation } from 'react-i18next';
import { Link } from 'react-router-dom';

interface Props {
    categoryId: string
}

function TopicAddBtn({ categoryId }: Props) {
    const { t } = useTranslation();

    return (
        <Fragment>
            <Link
                className="btn btn-success text-white sf-mb-1"
                role="button"
                to={`/category/${categoryId}/topic`}
            >
                {t('topics.add-topic')}
            </Link>
        </Fragment>
    );
}

export default TopicAddBtn;