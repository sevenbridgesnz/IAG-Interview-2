import { MenuItem } from '@material-ui/core';
import { Select } from '@mui/material';
import { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchMakesData } from '../store/makesSlice';

const MakeSelect = (props) => {
    const makes = useSelector((state) => state.makes.items);
    const dispatch = useDispatch();
    const [value, setValue] = useState('Lotus');

    useEffect(() => {
        dispatch(fetchMakesData(value));
      }, [dispatch, value]
    );

    const onChangeHandler = (event) => {
        setValue(event.target.value);
        props.onFilterChangedHandler(event.target.value);
    }


    return (
                <Select
                        id="modelSelect"
                        label="Model"
                        onChange={onChangeHandler}
                        value={value}
                        variant="standard"
                        >
                    {makes.map((make, index) => 
                                <MenuItem key={index} value={make}>{make}</MenuItem>
                            )}
                </Select>  

            )
}

export default MakeSelect;