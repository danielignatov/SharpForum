import './Footer.scss';
import React, { Fragment } from 'react';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

function Footer() {
    return (
        <Fragment>
            <Row>
                <Col>
                    <span className='sf-footer-text'><a href='https://github.com/danielignatov/SharpForum' className='sf-footer-link'>Sharp<strong>Forum</strong></a> 2022</span>
                </Col>
            </Row>
            <Row>
                <Col>
                    <span className='sf-footer-text'><small>by <strong>Daniel</strong>Ignatov</small></span>
                </Col>
            </Row>
        </Fragment>
    );
}

export default Footer;