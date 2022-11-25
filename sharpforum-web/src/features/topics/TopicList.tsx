import React from 'react';
import Table from 'react-bootstrap/Table';
import { Category } from '../../app/models/category';
import { Topic } from '../../app/models/topic';
import TopicListItem from './TopicListItem';

interface Props {
    category: Category,
    topics: Topic[]
}

export default function TopicList({ topics, category }: Props) {
    
    return (
        <Table bordered>
            <thead>
                <tr>
                    <th>{category.name}</th>
                </tr>
            </thead>
            <tbody>
                {topics?.map((topic: Topic) => (
                    <TopicListItem key={topic.id} topic={topic} />
                ))}
            </tbody>
        </Table>
    );
}