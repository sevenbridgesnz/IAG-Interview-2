import { createSlice } from '@reduxjs/toolkit';
import axios from 'axios';
import configData from './../config.json';

const initialState = {
    data: {
        make: "",
        status: "idle",
        models: []
    }
}

const modelSlice = createSlice({
    name: 'model',
    initialState: initialState,
    reducers: {
        replaceData(state, action) {
            state.data = action.payload;
            state.data.status = "idle"
        },

        fetching(state, action) {
            state.data.status = "fetching";
        },

        error(state, action) {
            state.data.models = [];
            state.data.make = action.payload;
            state.data.status = "error";
        }
    }
});

export const fetchModelsData = (makeName) => {
    return async dispatch => {
        const fetchData = async () => {

            const headers = {
                'Access-Control-Allow-Origin': '*'
            };


            const response = await axios.get(configData.API_BASE_URL + 'vehicle-checks/makes/' + makeName, { headers });

            if (response.status !== 200) {
                throw new Error('Could not fetch models data');
            }

            let data = await response.data;

            if (!data) {
                data = [];
            }

            return data;
        }

        try {
            dispatch(modelActions.fetching(makeName));
            const modelsData = await fetchData();

            dispatch(modelActions.replaceData(modelsData));
        } catch (error) {
            dispatch(modelActions.error(makeName));

            console.log('Error fetching Models data');
            console.log(error);
        }
    }
}


export default modelSlice.reducer;
export const modelActions = modelSlice.actions;