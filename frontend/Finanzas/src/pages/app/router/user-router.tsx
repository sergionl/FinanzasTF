import React from "react";
import { Route } from "react-router-dom";

import LoginForm from "../../user/login"
import UsersForm from "../../user/user-form"
import UsersDetails from "../../user/user-details"

function UserRouter(){
    return(
        <React.Fragment>
            
            <Route exact path="/" component={LoginForm} />
            <Route exact path="/register/:email" component={UsersForm} />
            <Route exact path="/register" component={UsersForm} />
            <Route exact path="/users/detail/:id" component={UsersDetails} />
        </React.Fragment>
    );

}
export default UserRouter;