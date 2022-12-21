import { Fragment } from 'react';
import AdminCategoryListItemPlaceholder from './AdminCategoryListItemPlaceholder';

function AdminCategoryListPlaceholder() {
  return (
      <Fragment>
          <AdminCategoryListItemPlaceholder categoryNameSize={3} categoryDescSize={8} isPlaceholder={true} />
          <AdminCategoryListItemPlaceholder categoryNameSize={4} categoryDescSize={7} />
          <AdminCategoryListItemPlaceholder categoryNameSize={5} categoryDescSize={6} />
          <AdminCategoryListItemPlaceholder categoryNameSize={4} categoryDescSize={7} isPlaceholder={true} />
          <AdminCategoryListItemPlaceholder categoryNameSize={3} categoryDescSize={6} />
          <AdminCategoryListItemPlaceholder categoryNameSize={5} categoryDescSize={8} />
      </Fragment>
  );
}

export default AdminCategoryListPlaceholder;