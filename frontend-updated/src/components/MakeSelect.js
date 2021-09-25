import { MenuItem } from '@material-ui/core';
import { Select } from '@mui/material';
import { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchMakesData } from '../store/makesSlice';

const MakeSelect = (props) => {
    const makes = useSelector((state) => state.makes.items);
    const dispatch = useDispatch();
    const [value, setValue] = useState('');

    useEffect(() => {
        dispatch(fetchMakesData(value));

    }, [dispatch, value]
    );

    useEffect(() => {
        if (makes.length > 0 && value === '') {
            setValue(makes[0]);
        }

    }, [makes, value, props])

    const onChangeHandler = (event) => {
        setValue(event.target.value);
        props.onFilterSelectHandler(event.target.value);
    }

    // console.log(makes);

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