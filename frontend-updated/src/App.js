import './App.css';

import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import CarList from './components/CarList';


function App() {
    return (
      <div>
        <AppBar position="static">
          <Toolbar variant="dense">
            <Typography variant="h6" color="inherit">
              Vehicle List
            </Typography>
          </Toolbar>
        </AppBar>
        <CarList></CarList>
      </div>
    );
}

export default App;
