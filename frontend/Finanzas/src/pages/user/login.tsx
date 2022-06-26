import { Button, Grid } from "@material-ui/core";
import React, { useEffect, useState } from "react";
import CustomBody from "../../components/body-custom/custom-body";
import CustomBodyDescription from "../../components/body-custom/custom-body-description";
import CustomBodyName from "../../components/body-custom/custom-body-name";
import CustomTextField from "../../components/custom-text-field/custom-text-field";
import CustomMainForm from "../../components/form/custom-main-form";

import {Link, useHistory, useParams, useRouteMatch} from "react-router-dom";
import {Login} from "../../models/login"
import {User} from "../../models/user"

import apiUsers from "../../api/api.user"


function LoginForm(){
    const history = useHistory();
    const [open, setOpen] = useState(false);
    const [loading, setLoading] = useState(false);
    const [initialLoading, setInitialLoading] = useState(true);
    const [message, setMessage] = useState("");

    const[userLogin,setUserLogin] = useState<Login>(new Login());

    //console.log("hola")

    function changeValueUserLogin(
        event: React.ChangeEvent<HTMLTextAreaElement | HTMLInputElement>
    ) {
        const { value, name } = event.target;
        setUserLogin({ ...userLogin, [name]: value });
        //console.log(userLogin)
    }

    function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();
        console.log("hola");
       //login
       apiUsers.login(userLogin.email,userLogin.password).then((data)=>{
           data.id ? history.push(`/users/detail/${data.id}`) :
               //history.push(`/register/${userLogin.email}`);
               history.push(`/register`);
       });
        
        

      }


    return(
        <React.Fragment>
            <CustomBody>
            <CustomMainForm
                title="Iniciar sesión"
            >
                <form onSubmit={handleSubmit}>
                    <React.Fragment>
                        <Grid container spacing={2}>
                          <Grid item xs={6} sm={12}>
                            <CustomTextField
                              value={userLogin.email}
                              onChange={(event) => changeValueUserLogin(event)}
                              required
                              name="email"
                              label="Correo Electrónico"
                            />
                          </Grid>
                          <Grid item xs={6} sm={12}>
                            <CustomTextField
                              value={userLogin.password}
                              onChange={(event) => changeValueUserLogin(event)}
                              required
                              name="password"
                              label="Contraseña"
                              type="password"
                            />
                          </Grid>
                        </Grid>
                        <Grid container spacing={2} style={{ marginTop: "15px"}} >
                            <Grid item xs={12} sm={6}>
                                <Button
                                component={Link}
                                to={`/register`}
                                startIcon={<span className="material-icons"></span>}
                                >
                                    No tengo cuenta
                                </Button>
                            </Grid>
                            <Grid item xs={12} sm={6} style={
                                { display: "flex", justifyContent: "flex-end"}}>
                                <Button
                                    type={"submit"}
                                    variant="contained"
                                    color={"primary"}
                                    startIcon={<span className="material-icons">Iniciar Seccion</span>}
                                    disabled={loading}
                                >
                                
                                </Button>
                            </Grid>
                        </Grid>


                    </React.Fragment>

                </form>
            </CustomMainForm>
            </CustomBody>
        </React.Fragment>

    );

}

export default LoginForm;