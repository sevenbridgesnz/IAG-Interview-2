import { Fragment, useEffect, useState } from "react";
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import MakeSelect from "./MakeSelect";
import { useDispatch, useSelector } from "react-redux";
import { fetchModelsData } from "../store/modelsSlice";
import { FormControl, TextField } from "@material-ui/core";
import { Backdrop, CircularProgress } from '@material-ui/core';


const CarList = () => {
    const models = useSelector((state) => state.models);
    const dispatch = useDispatch();

    const [filter, setFilter] = useState('');
    const [currentModel, setCurrentModel] = useState('Lotus');

    useEffect(() => {
        dispatch(fetchModelsData(currentModel));
    }, [dispatch, currentModel]
    );

    const onFilterChangeHandler = (event) => {
        setFilter(event.target.value);
    }

    const onMakeSelectChangedHandler = (makeName) => {
        setCurrentModel(makeName);
    }

    return (
        <Fragment>
            <Backdrop
                sx={{ color: '#fff', zIndex: (theme) => theme.zIndex.drawer + 1 }}
                open={models.data.status === 'fetching'}>
                <CircularProgress color="inherit" />
            </Backdrop>

            <FormControl variant="standard" sx={{ m: 2, minWidth: 120 }}>
                <MakeSelect id="makeSelect" onFilterSelectHandler={onMakeSelectChangedHandler}></MakeSelect>
                <TextField id="filter-id" label="Filter" onChange={onFilterChangeHandler} />
            </FormControl>

            {models.data.status === 'error' && <h4 id="load-error-label">There was an error fetching the data</h4>}
            {models.data.status === 'idle' &&
                <Paper>
                    <Table aria-label="simple table">
                        <TableHead>
                            <TableRow>
                                <TableCell>Name</TableCell>
                                <TableCell>Years Available</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>

                            {models.data.models
                                .filter(function (e) {
                                    return filter.length === 0 || e.name.toUpperCase().includes(filter.toUpperCase());
                                })
                                .map(model => (
                                    <TableRow key={model.name + model.yearsAvailable}>
                                        <TableCell component="th" scope="row">
                                            {model.name}
                                        </TableCell>
                                        <TableCell>{model.yearsAvailable}</TableCell>
                                    </TableRow>
                                ))}
                        </TableBody>
                    </Table>
                </Paper>
            }
        </Fragment>
    );
}

export default CarList;