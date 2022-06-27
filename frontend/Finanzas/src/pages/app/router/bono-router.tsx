import React from "react";
import { Route } from "react-router-dom";


import BonoList from "../../bono/bono-list";
import BonoForm from "../../bono/bono-form";
import BonoDetails from "../../bono/bono-detail";


function BonoRouter(){
    return(
        <React.Fragment>
            <Route exact path="/bonos/list" component={BonoList} />
            <Route exact path="/bonos/create" component={BonoForm} />
            <Route exact path="/bono/detail/:id" component={BonoDetails} />

        </React.Fragment>

    );
}

export default BonoRouter;