import './App.css';

import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import CarList from './components/CarList';
import { Fragment } from 'react';


function App() {
  return (
    <Fragment>
      <AppBar position="static">
        <Toolbar variant="dense">
          <Typography variant="h6" color="inherit">
            Vehicle List
          </Typography>
        </Toolbar>
      </AppBar>
      <CarList></CarList>
    </Fragment>
  );
}

export default App;
