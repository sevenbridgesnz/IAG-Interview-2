import { configureStore } from '@reduxjs/toolkit';
import makeSlice from './makesSlice';
import modelsSlice from './modelsSlice';

const store = configureStore({
    reducer: {
        makes: makeSlice,
        models: modelsSlice
    }
});

export default store;