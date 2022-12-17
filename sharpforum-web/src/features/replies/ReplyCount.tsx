import { Fragment } from 'react';
import { useTranslation } from 'react-i18next';

interface Props {
    value: number
}

function ReplyCount({ value }: Props) {
    const { t } = useTranslation();

    return (
        <Fragment>
            {value === 1 ? (
                <small>{value} {t('replies.singular-l')}</small>
            ) : (
                <small>{value} {t('replies.title-l')}</small>
            )}
        </Fragment>
    );
}

export default ReplyCount;