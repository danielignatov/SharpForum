import { NavDropdown } from 'react-bootstrap';
import { useTranslation } from 'react-i18next';

function Language() {
    const { i18n } = useTranslation();
    const { t } = useTranslation();

    const changeLanguage = (lng: string) => {
        i18n.changeLanguage(lng);
    };

    return (
        <NavDropdown title={t('layout.nav.lang')} id="basic-nav-dropdown">
            <NavDropdown.Item onClick={() => changeLanguage('en')}>
                {t('layout.nav.en')}
            </NavDropdown.Item>
            <NavDropdown.Item onClick={() => changeLanguage('bg')}>
                {t('layout.nav.bg')}
            </NavDropdown.Item>
        </NavDropdown>
    );
}

export default Language;