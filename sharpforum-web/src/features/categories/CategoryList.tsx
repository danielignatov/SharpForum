import Table from 'react-bootstrap/Table';
import './CategoryList.css';
import { Category } from '../../app/models/category';
import CategoryListItem from './CategoryListItem';
import { gql, useQuery } from '@apollo/client';
import Loading from '../../layouts/Loading';

const GetAllCategoriesQuery = gql`
    query {
        categories {
          id,
          name,
          description,
          displayOrder,
          isPlaceholder
        }
    }
`;

export default function CategoryList() {
    const { loading, error, data } = useQuery(GetAllCategoriesQuery);

    if (loading) return <Loading />;
    if (error) return <pre>{error.message}</pre>

    return (
        <Table bordered>
            <thead>
                <tr>
                    <th>Categories</th>
                </tr>
            </thead>
            <tbody>
                {data?.categories?.map((category: Category) => (
                    <CategoryListItem key={category.id} category={category} />
                ))}
            </tbody>
        </Table>
    );
}