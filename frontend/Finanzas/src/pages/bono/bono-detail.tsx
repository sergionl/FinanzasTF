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

    function VAN(){
        let van = 0.0;
        let ta = bono.tasaAnual/100;
        let interes = bono.valorNominal*ta;
        //console.log(interes);
        //var van = new bigDecimal(0.0);
        //var interes = bigDecimal.multiply(bono.valorNominal,ta);

        //console.log(ta);
        //console.log(interes);
        for(let i = 1;i<bono.tiempo+1;i++){
            if(i != bono.tiempo){
                //console.log(i);
                let aux = fv(ta,i,-interes,0);
                console.log(aux);
                van += aux;
                
            }else{
                let aux = fv(ta,i,-interes-bono.valorNominal,0);
                van+= aux;
                console.log(aux);
            }

            //console.log(van);

        }
        return van;
    }
    let van = VAN();

    function TIR(){
        let tir = 0;


        return tir;
    }
    let tir = TIR();

    function convex(){
        let c = 0;

        return c;
    }
    let c = convex();

    return(
        <React.Fragment>
            <CustomBodyName>Detalles bono</CustomBodyName>
            <CustomCardHeader>
            <h3> Detalles del bono : {bono.nombre} </h3>
          </CustomCardHeader>
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
                <p> {van} </p>
                <h5> TIR: </h5>
                <p> {tir} </p>
                <h5> Convex: </h5>
                <p> {c} </p>
                </Grid >
            </Grid >
          </CustomCardBody>
        </React.Fragment>
    );
}
export default BonoDetails;