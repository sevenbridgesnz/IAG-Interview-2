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

    const mySelectControl = await screen.findByDisplayValue('Lotus');

    expect(mySelectControl).toBeInTheDocument();
  });

  /*
  test('Select component renders and emits value', async () => {
    let selectedValue = '';

    const onMakeSelectChangedHandler = (val) => {
      selectedValue = val;
      console.log('value emitted');
    }

    render(<Provider store={store}>
      <MakeSelect id="makeSelect" onFilterSelectHandler={onMakeSelectChangedHandler}></MakeSelect>
    </Provider>
    );

    const mySelectControl = await screen.findByDisplayValue('Lotus');

    console.log('selected value is');
    console.log(selectedValue);

    expect(mySelectControl).toBeInTheDocument();
    //expect(selectedValue).toBe('Lotus');
  });
*/
});