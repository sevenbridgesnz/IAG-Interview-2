import { render, screen } from "@testing-library/react";
import { Provider } from "react-redux";
import MakeSelect from "../../components/MakeSelect";
import store from "../../store";

describe('MakeSelect Component', () => {
  test('Select component renders and loads data', async () => {

    render(<Provider store={store}>
      <MakeSelect id="makeSelect" ></MakeSelect>
    </Provider>
    );

    const mySelectControl = await screen.findByRole('button');

    expect(mySelectControl).toBeInTheDocument();
  });
});