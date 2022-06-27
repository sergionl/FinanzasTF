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

import apiBonos from "../../api/api.bono";
import {Bono} from "../../models/bono";


function BonoList(){
    const [initialLoading, setInitialLoading] = useState(true);
    const [loading, setLoading] = useState(false);
    const [bono, setBono] = useState<Bono[]>([]);
    const [target, setTarget] = useState("");

    function changeRemove(
        event: React.MouseEvent<HTMLButtonElement, MouseEvent>,
        id: number
    ) {
        const customer = bono.find((x) => x.id === id);

        if (customer) {
            //Delete
            setTarget(event.currentTarget.name);
            setLoading(true);
            apiBonos.delete(id).then(() => {
                setLoading(false);
                setBono(
                    bono.filter((x) => x.id !== id)
                );
            });
        }
    }
    useEffect(() => {
        apiBonos.list().then((data) => {
            setBono(data);
            setInitialLoading(false);
            console.log(data);
        });
    }, []);

    return (
        <React.Fragment>
            <Grid item xs={12} md={8} lg={5}>
                <Paper
                    style={{
                        padding: "16px",
                        display: "flex",
                        flexDirection: "column",
                        height: 150,
                    }}
                >
                    <Typography variant="h5">Estas en:</Typography>
                    <Divider />

                    <Typography style={{ marginTop: "10px" }} variant="body2">
                        Listar Bonos
                    </Typography>
                </Paper>
            </Grid>
            {/* Recent Deposits */}
            <Grid item xs={12} md={4} lg={7}>
                <Paper
                    style={{
                        padding: "16px",
                        display: "flex",
                        flexDirection: "column",
                        height: 150,
                    }}
                >
                    <Typography variant="h5">Descripcion:</Typography>
                    <Divider />

                    <Typography style={{ marginTop: "10px" }} variant="body2">
                        Se encarga de listar los bonos disponibles
                    </Typography>
                </Paper>
            </Grid>
            {/* Recent Orders */}
            <Grid item xs={12}>
                <Paper
                    style={{
                        padding: "16px",
                        display: "flex",
                        flexDirection: "column",
                    }}
                >
                    <React.Fragment>
                        <Title>Lista de Bonos</Title>
                        <TableContainer component={Paper}>
                            <Table size="small">
                                <TableHead>
                                    <TableRow>
                                        <TableCell>Nro</TableCell>
                                        <TableCell>Nombre</TableCell>
                                        <TableCell>Precio</TableCell>
                                        <TableCell>Mercado</TableCell>
                                        <TableCell>Moneda</TableCell>
                                        <TableCell>Detalle</TableCell>
                                        
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {bono.map((x, index) => (
                                        <TableRow key={x.id}>
                                            <TableCell>{index + 1}</TableCell>
                                            <TableCell> {x.nombre}</TableCell>
                                            <TableCell>{x.precio}</TableCell>
                                            <TableCell> 
                                                {x.mercadoPrimario == true ? "Primario" : "Secundario"}
                                            </TableCell>
                                            <TableCell> 
                                                {x.soles == true ? "Soles" : "Dolares"}
                                            </TableCell>
                                            
                                            <TableCell>
                                                <Button
                                                    component={Link}
                                                    to={`/bono/detail/${x.id}`}
                                                    size={"small"}
                                                    variant="contained"
                                                    color="default"
                                                    style={{ width: "100px" }}
                                                    startIcon={
                                                        <span className="material-icons">Detalles</span>
                                                    }
                                                >
                                                    
                                                </Button>
                                            </TableCell>
                                            
                                        </TableRow>
                                    ))}
                                </TableBody>
                            </Table>
                        </TableContainer>
                    </React.Fragment>
                </Paper>
            </Grid>
        </React.Fragment>
        /*<div>
           {customers.map((customer) => (
              <p key="{customer.customerId}">
                {customer.customerName} - {customer.customerDirection}
              </p>
            ))}
          </div>*/
    );
}

export default BonoList;