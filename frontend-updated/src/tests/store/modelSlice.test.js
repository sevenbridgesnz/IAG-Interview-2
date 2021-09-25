
import { reducer, createSlice, createSelector, configureStore } from '@reduxjs/toolkit';
import modelsSlice from './../../store/modelsSlice';

describe('Redux - model slice', () => {
    test('Can load data well', () => {
        const initialState = {
            data: {
                make: "",
                status: "idle",
                models: []
            }
        }

        const testStore = configureStore({
            reducer: {
                models: modelsSlice
            }
        });



    });
});