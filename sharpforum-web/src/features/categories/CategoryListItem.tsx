import { Fragment } from 'react';
import { Link } from 'react-router-dom';
import { Category } from '../../app/models/category';
import Row from 'react-bootstrap/Row';

interface Props {
    category: Category
}

function CategoryListItem({ category }: Props) {
    return (
        <Fragment>
            {category.isPlaceholder ? (
                <tr className='placeholder-category'>
                    <td>
                        <Row>
                            <strong>{category.name}</strong>
                        </Row>
                        <Row>
                            <small>{category.description}</small>
                        </Row>
                    </td>
                </tr>
            ) : (
                <tr>
                    <td>
                            <Row>
                                <Link to={`/category/${category.id}`} className='sf-link'><strong>{category.name}</strong></Link>
                        </Row>
                        <Row>
                            <small>{category.description}</small>
                        </Row>
                    </td>
                </tr>
            )}

        </Fragment>
    );
}

export default CategoryListItem;