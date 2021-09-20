import logo from './logo.svg';
import './App.css';
import { useState } from 'react';

import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';

function App() {

  const [data, setData] = useState(
    {
      models: [
        {name: 'Some car', yearsAvailable: '2010' },
        {name: 'Another car', yearsAvailable: '2001' }

      ]
    }
    
  );

  // function componentDidMount() {
  //   fetch('https://localhost:44387/vehicle-checks/makes/Lotus')
  //     .then(res => res.json())
  //     .then(vehicles => {
  //       setData({ models: vehicles.models });

  //       console.log({ models: vehicles.models });
  //     })
  //     .catch(console.log);
  // }

    return (
      <div>
        <AppBar position="static">
          <Toolbar variant="dense">
            <Typography variant="h6" color="inherit">
              Vehicle List
            </Typography>
          </Toolbar>
        </AppBar>
        <Typography variant="h5" component="h2">
          Lotus
        </Typography>
        <Paper>
          <Table aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>Name</TableCell>
                <TableCell>Years Available</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
             {data.models.map(model => (
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
      </div>
    );
}

export default App;
