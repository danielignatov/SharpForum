//import { Component } from 'react';
import Table from 'react-bootstrap/Table';
import Row from 'react-bootstrap/Row';
import './CategoryList.css';

const CategoryList = (props: any) => {
    const { name } = props;
    return (
        <Table bordered hover>
            <thead>
                <tr>
                    <th>Category name</th>
                </tr>
            </thead>
            <tbody>
                <tr className='supercategory'>
                    <td>
                        <Row>
                            <strong>Красота</strong>
                        </Row>
                        <Row>
                            <small>Desc</small>
                        </Row>
                    </td>
                </tr>
                <tr>
                    <td>
                        <Row>
                            <strong>Красота</strong>
                        </Row>
                        <Row>
                            <small>Desc</small>
                        </Row>
                    </td>
                </tr>
                <tr>
                    <td>
                        <Row>
                            <strong>Красота</strong>
                        </Row>
                        <Row>
                            <small>Desc</small>
                        </Row>
                    </td>
                </tr>
            </tbody>
        </Table>
    );
}

export default CategoryList;