import { createSlice } from '@reduxjs/toolkit';

const makeSlice = createSlice ({
    name: 'make', 
    initialState: {
        items: []
    },
    reducers: {
        replaceData(state, action) {
            console.log('Redux level');
            console.log(action.payload);
            state.items = action.payload;
        }
    }
});


export const fetchMakesData = () => {
    return async dispatch => {
        const fetchData = async () => {
            const response = await fetch(
                'https://localhost:44387/vehicle-checks/makes/',{ }
            );

            if (!response.ok) {
                throw new Error('Could not fetch makes data');
            }
            
            let data = await response.json();

            if (!data)
            {
                data = [];    
            }
            
            return data;
        }

        try {
            const makesData = await fetchData();
            console.log('Makes data fetched');
            console.log(makesData);

            //update redux slice
            dispatch(makeActions.replaceData(makesData));
        } catch (error) {
            console.log('Error fetching makes data');
        }
    }
}


export default makeSlice.reducer;
export const makeActions = makeSlice.actions;