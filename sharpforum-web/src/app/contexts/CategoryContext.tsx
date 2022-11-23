import { createContext, useState, useEffect } from 'react';
import { gql, useQuery } from '@apollo/client';
//import { JsxElement } from 'typescript';

export const CategoryContext = createContext({
    categoriesMap: {}
});

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

export const CategoryProvider = ({}) => {
    const { loading, error, data } = useQuery(GetAllCategoriesQuery);
    const [categoriesMap, setCategoriesMap] = useState({});

    useEffect(() => {
        if (data) {
            const { categories } = data;
            const categoriesMap = categories.reduce((acc: any, category: any) => {
                const { id, items } = category;
                acc[id] = items;
                return acc;
            }, {});

            setCategoriesMap(categoriesMap);
        }
    }, [data]);

    console.log('data', data);

    const value = { categoriesMap, loading };

    return (
        <CategoryContext.Provider value={value}>
            {}
        </CategoryContext.Provider>
    );
}