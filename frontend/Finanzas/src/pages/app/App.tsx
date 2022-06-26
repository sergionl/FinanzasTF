import React from "react";
import { MuiThemeProvider } from "@material-ui/core";
import themeMui from "../../themes/theme-mui";
import Dashboard from "../../components/dashboard/dashboard";
import { BrowserRouter as Router, Switch } from "react-router-dom";

import UserRouter from "./router/user-router";

import DateFnsUtils from '@date-io/date-fns';
import { MuiPickersUtilsProvider } from "@material-ui/pickers";
//import moment from 'moment-timezone'

//let launchMoment = require('moment')
//require('moment-timezone')
//moment.tz('America/New_York')
function App() {
  return (
    <Router>
    <MuiPickersUtilsProvider utils={DateFnsUtils}>

      <MuiThemeProvider theme={themeMui}>
        
        <Switch>
          <Dashboard>
            

            <UserRouter />
            
          </Dashboard>
        </Switch>
      </MuiThemeProvider>

    </MuiPickersUtilsProvider>
    </Router>
  );
}

export default App;
