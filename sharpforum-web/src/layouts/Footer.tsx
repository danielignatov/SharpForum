import './Footer.scss';
import React, { Fragment } from 'react';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Link } from 'react-router-dom';
import { useTranslation } from 'react-i18next';

function Footer() {
    const { t } = useTranslation();

    return (
        <Fragment>
            <Row>
                <Col>
                    <p className='sf-footer-text'>
                        <Link to='/privacy' className='sf-footer-link'>{t("privacy.title")}</Link>
                    </p>
                </Col>
                <Col>
                    <p className='sf-footer-text text-end'>
                        <a href='https://github.com/danielignatov/SharpForum' className='sf-footer-link'>Sharp<strong>Forum</strong></a> 2022
                        <br />
                        <small>{t("common.by")} <strong>Daniel</strong>Ignatov</small>
                    </p>
                </Col>
            </Row>
        </Fragment>
    );
}

export default Footer;