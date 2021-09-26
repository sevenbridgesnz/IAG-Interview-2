import { fireEvent, render, screen } from "@testing-library/react";
import { Provider } from "react-redux";
import CarList from "../../components/CarList";
import store from "../../store";


describe('CarList Component', () => {
    test('Car List component renders and loads data', async () => {

        render(<Provider store={store}>
            <CarList id="makeSelect" ></CarList>
        </Provider>
        );

        const myTable = await screen.findByRole('table');

        expect(myTable).toBeInTheDocument();
    });

    test('Car List component renders all rows', async () => {

        render(<Provider store={store}>
            <CarList id="makeSelect" ></CarList>
        </Provider>
        );

        const myRows = await screen.findAllByRole('row');

        //8 rows plus header
        expect(myRows).toHaveLength(9);
    });

    test('Car List filters records correctly', async () => {

        render(<Provider store={store}>
            <CarList id="makeSelect" ></CarList>
        </Provider>
        );

        const myFilterField = screen.getByRole('textbox', { name: 'Filter' });

        await fireEvent.change(myFilterField, { target: { value: 'el' } });

        const myRows = await screen.findAllByRole('row');

        //4 rows plus header
        expect(myRows).toHaveLength(5);
    });
});