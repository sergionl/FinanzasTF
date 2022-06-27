import {
    Button,
    Divider,
    Grid,
    Paper,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Typography,
} from "@material-ui/core";

import React, { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import Title from "../../components/dashboard/title";
import CustomBody from "../../components/body-custom/custom-body";
import CustomBodyDescription from "../../components/body-custom/custom-body-description";
import CustomBodyName from "../../components/body-custom/custom-body-name";
import CustomCardBody from "../../components/custom-card/custom-card-body/custom-card-body";
import CustomCardHeader from "../../components/custom-card/custom-card-header/custom-card-header";
import CustomCard from "../../components/custom-card/custom-card/custom-card";
import { fv,pmt } from 'financial';
//import bigDecimal require('js-big-decimal');

import apiBonos from "../../api/api.bono";
import {Bono} from "../../models/bono";
import bigDecimal from "js-big-decimal";

function BonoDetails(){
    const [initialLoading, setInitialLoading] = useState(true);
    const [bono, setBono] = useState<Bono>(new Bono());
    const { id } = useParams<{ id: string }>();

    useEffect(() => {
        if (id) {
            apiBonos.detail(id).then((data) => {
                setBono(data);
              //setInitialLoading(false);
            });
        }
    }, [id]);

    

  

   

    return(
        <React.Fragment>
            <CustomBodyName>Detalles del bono</CustomBodyName>
            
          <CustomCardBody>
            <Grid container>
                <Grid item xs={12} sm={12} md={6}>
                <h3> Detalles del Bono: </h3>
                <h5> Valor Nominal: </h5>
                <p>{bono.valorNominal}</p>
                <h5> Tasa Efectiva Anual: </h5>
                <p> {bono.tasaAnual} </p>
                <h5> Periodo de Pago: </h5>
                <p> {bono.periodoDePago} </p>
                <h5> Tiempo: </h5>
                <p> {bono.tiempo} </p>
                <h5> VAN: </h5>
                <p> {bono.van} </p>
                <h5> TIR: </h5>
                <p> {bono.tir} </p>
                <h5> Convex: </h5>
                <p> {bono.convex} </p>
                </Grid >
            </Grid >
          </CustomCardBody>
        </React.Fragment>
    );
}
export default BonoDetails;