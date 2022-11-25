import { gql, useQuery } from '@apollo/client';
import React, { Fragment } from 'react';
import Button from 'react-bootstrap/Button';
import { useParams } from 'react-router-dom';
import Loading from '../../layouts/Loading';
import TopicList from '../topics/TopicList';

const GetCategoryTopicsQuery = gql`
    query GetCategoryTopicsQuery($categoryId: UUID) {
        topics (where: {categoryId: {eq: $categoryId}} ) {
          id,
          subject,
          locked,
          authorId,
          author {
            displayName
          },
          categoryId,
          category {
            name
          },
          createdOn
        }
    }
`;

function CategoryDetails() {
    const { categoryId } = useParams<{ categoryId: string }>();

    const { loading, error, data } = useQuery(GetCategoryTopicsQuery, { variables: { categoryId } });

    if (loading) return <Loading />;
    if (error) return <pre>{error.message}</pre>

    return (
        <Fragment>
            <Button variant='success' className='sf-mb-1'>Add Topic</Button>
            <TopicList topics={data.topics} />
        </Fragment>
    );
}

export default CategoryDetails;