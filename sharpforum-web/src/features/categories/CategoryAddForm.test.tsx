import React from 'react';
import { render, screen } from '@testing-library/react';
import userEvent from '@testing-library/user-event';
import { MemoryRouter } from 'react-router-dom';
import CategoryAddForm from './CategoryAddForm';
import { StoreContext } from '../../app/stores/store';

jest.mock('react-i18next', () => ({
  useTranslation: () => ({
    t: (key: string) => key,
  }),
}));

it('shows validation error when submitting empty form', async () => {
  const add = jest.fn().mockResolvedValue({ success: true, errors: [] });
  const store = {
    categoryStore: { add },
    userStore: { isAdmin: true },
    topicStore: {},
    replyStore: {},
  } as any;

  render(
    <StoreContext.Provider value={store}>
      <MemoryRouter>
        <CategoryAddForm />
      </MemoryRouter>
    </StoreContext.Provider>
  );

  await userEvent.click(screen.getByRole('button'));

  expect(await screen.findByText('common.req-field')).toBeInTheDocument();
});
