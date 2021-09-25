import { createSlice } from '@reduxjs/toolkit';
import axios from 'axios';
import configData from './../config.json';

const makeSlice = createSlice({
    name: 'make',
    initialState: {
        items: []
    },
    reducers: {
        replaceData(state, action) {
            state.items = action.payload;
        }
    }
});

export const fetchMakesData = () => {
    return async dispatch => {
        const fetchData = async () => {
            const headers = {
                'Access-Control-Allow-Origin': '*'
            };


            const response = await axios.get(configData.API_BASE_URL + 'vehicle-checks/makes', { headers });

            if (response.status !== 200) {
                throw new Error('Could not fetch makes data');
            }

            let data = await response.data.makes;

            if (!data) {
                data = [];
            }

            return data;
        }

        try {
            const makesData = await fetchData();

            dispatch(makeActions.replaceData(makesData));
        } catch (error) {
            console.log('Error fetching makes data');
            console.log(error);
        }
    }
}


export default makeSlice.reducer;
export const makeActions = makeSlice.actions;