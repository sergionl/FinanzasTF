import * as React from "react";
import ListItem from "@material-ui/core/ListItem";
import ListItemIcon from "@material-ui/core/ListItemIcon";
import ListItemText from "@material-ui/core/ListItemText";
import ListSubheader from "@material-ui/core/ListSubheader";
import DashboardIcon from "@material-ui/icons/Dashboard";
import AssignmentIcon from "@material-ui/icons/Assignment";
import { NavLink } from "react-router-dom";
import { User } from "../../models/user";

const appUserData:User = Object.assign(new User,
  JSON.parse(localStorage.getItem('appUserData')));
  
  export const mainListItems = (
  <div>
    <ListItem
      button
      exact
      component={NavLink}
      to={"/"}
      activeClassName="Mui-selected"
    >
      <ListItemIcon>
        <DashboardIcon />
      </ListItemIcon>
      <ListItemText primary="Bonera" />
    </ListItem>
  </div>
);

export const secondaryListItems = (
  <div>
    <ListSubheader inset>Bonos</ListSubheader>
      <ListItem
          button
          component={NavLink}
          //Agrega al router el "to"
          to={"/bonos/list"}
          activeClassName="Mui-selected"
      >
          <ListItemIcon>
              <AssignmentIcon />
          </ListItemIcon>
          <ListItemText primary="Mostrar Bonos" />
      </ListItem>
      <ListItem
          button
          component={NavLink}
          //Agrega al router el "to"
          to={"/bonos/create"}
          activeClassName="Mui-selected"
      >
          <ListItemIcon>
              <AssignmentIcon />
          </ListItemIcon>
          <ListItemText primary="Agregar Bonos" />
      </ListItem>

    

    
      
    

    
    
  </div>
);
