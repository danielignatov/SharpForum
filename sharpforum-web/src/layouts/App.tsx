import './App.css';
import CategoryList from '../features/categories/CategoryList';
import { gql, useQuery } from '@apollo/client';

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

function App() {
    const { loading, error, data } = useQuery(GetAllCategoriesQuery);

    if (loading) return <p>Loading...</p>;
    if (error) return <pre>{error.message}</pre>

    //console.log('data', data);

    return (
        <CategoryList categories={data.categories} />
  );
}

export default App;