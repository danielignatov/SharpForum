import { useState, useEffect } from 'react';
import { Category } from "../models/category";
//import { dataStore } from "./dataStore";
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

export default class CategoryDataStore {
    categoryRegistry = new Map<string, Category>();
    selectedCategory: Category | undefined = undefined;
    loading = false;
    predicate = new Map().set('all', true);

    constructor() {
        this.categoryRegistry.clear();
        this.loadCategories();
    }

    loadCategories = async () => {
        try {
            debugger;
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

            //const value = { categoriesMap, loading };
        } catch (error) {
            console.log(error);
        }
    }
}