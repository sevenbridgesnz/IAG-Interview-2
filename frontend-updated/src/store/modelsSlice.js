import { createSlice } from '@reduxjs/toolkit';

const initialState = {
    data: {
        make: "",
        status: "idle",
        models: []
    }
}

const modelSlice = createSlice ({
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
            const response = await fetch(
                'https://localhost:44387/vehicle-checks/makes/'+makeName,{ }
            );

            if (!response.ok) {
                throw new Error('Could not fetch models data');
            }
            
            let data = await response.json();

            if (!data)
            {
                data = [];    
            }
            
            return data;
        }

        try {
            dispatch(modelActions.fetching(makeName));
            const modelsData = await fetchData();

            //update redux slice
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