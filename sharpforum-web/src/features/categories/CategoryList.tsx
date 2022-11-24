import React from 'react';
import Table from 'react-bootstrap/Table';
import './CategoryList.css';
import { Category } from '../../app/models/category';
import CategoryListItem from './CategoryListItem';

interface Props {
    categories: Category[]
}

export default function CategoryList({ categories }: Props) {
    
    return (
        <Table bordered>
            <thead>
                <tr>
                    <th>Category name</th>
                </tr>
            </thead>
            <tbody>
                {categories?.map((category: Category) => (
                    <CategoryListItem key={category.id} category={category} />
                ))}
            </tbody>
        </Table>
    );
}