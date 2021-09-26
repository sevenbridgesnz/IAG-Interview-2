import { render, screen } from '@testing-library/react';
import { Provider } from 'react-redux';
import App from '../App';
import store from '../store/index';

describe('Full Application', () => {
  test('renders learn react link', async () => {
    render(<Provider store={store}>
      <App></App>
    </Provider>
    );

    await screen.findAllByRole('button');
  });
});