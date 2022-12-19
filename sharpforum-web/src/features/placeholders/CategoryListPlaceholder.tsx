import { Fragment } from 'react';
import CategoryListItemPlaceholder from './CategoryListItemPlaceholder';

function CategoryListPlaceholder() {
  return (
      <Fragment>
          <CategoryListItemPlaceholder categoryNameSize={3} categoryDescSize={8} isPlaceholder={true} />
          <CategoryListItemPlaceholder categoryNameSize={4} categoryDescSize={7} />
          <CategoryListItemPlaceholder categoryNameSize={5} categoryDescSize={6} />
          <CategoryListItemPlaceholder categoryNameSize={4} categoryDescSize={7} isPlaceholder={true} />
          <CategoryListItemPlaceholder categoryNameSize={3} categoryDescSize={6} />
          <CategoryListItemPlaceholder categoryNameSize={5} categoryDescSize={8} />
      </Fragment>
  );
}

export default CategoryListPlaceholder;