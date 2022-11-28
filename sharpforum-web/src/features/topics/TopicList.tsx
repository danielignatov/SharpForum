import React from 'react';
import Table from 'react-bootstrap/Table';
import { Topic } from '../../app/models/topic';
import TopicListItem from './TopicListItem';

interface Props {
    topics: Topic[]
}

export default function TopicList({ topics }: Props) {
    
    return (
        <Table bordered bgcolor='white'>
            <thead>
                <tr>
                    <th>Topics</th>
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