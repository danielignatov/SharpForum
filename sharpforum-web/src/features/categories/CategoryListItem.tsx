import React from 'react';
import { Link } from 'react-router-dom';
import { Category } from '../../app/models/category';
import Row from 'react-bootstrap/Row';

interface Props {
    category: Category
}

function CategoryListItem({ category }: Props) {
    return (
        //<Link to={`/category/${category.id}`}>
        <tr className={category.isPlaceholder ? 'placeholder-category' : ''}>
            <td>

                <Row>
                    <strong>{category.name}</strong>
                </Row>
                <Row>
                    <small>{category.description}</small>
                </Row>
            </td>
        </tr>
        //
    );
}

export default CategoryListItem;