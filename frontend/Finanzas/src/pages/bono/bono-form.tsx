import { Button, Grid } from "@material-ui/core";
import React, { useEffect, useState } from "react";
import CustomBody from "../../components/body-custom/custom-body";
import CustomBodyDescription from "../../components/body-custom/custom-body-description";
import CustomBodyName from "../../components/body-custom/custom-body-name";
import CustomTextField from "../../components/custom-text-field/custom-text-field";
import CustomMainForm from "../../components/form/custom-main-form";
import CustomSelect from "../../components/custom-select/custom-select";

import { useHistory, useParams } from "react-router-dom";

import apiBonos from "../../api/api.bono";
import {Bono} from "../../models/bono";

function BonoForm(){
    const history = useHistory();

  const [open, setOpen] = useState(false);
  const [loading, setLoading] = useState(false);
  const [initialLoading, setInitialLoading] = useState(true);
  const [message, setMessage] = useState("");
  const [bono, setBono] = useState<Bono>(new Bono());

  function changeValueBono(
    event: React.ChangeEvent<HTMLTextAreaElement | HTMLInputElement>
  ) {
    const { value, name } = event.target;
    setBono({ ...bono, [name]: value });
  }
  //default values
  bono.convex=0;
  bono.van=0;
  bono.tir=0;

  function handleSubmit(event: React.FormEvent<HTMLFormElement>){
        //console.log(bono);
      /*setLoading(true);*/
        event.preventDefault();
        //console.log(bono);
        apiBonos.add(bono)//.then(() => {
            //updatedLoading();
            //console.log(bono);
        //history.push("/bonos/list");
            //console.log("resultado");

        //setMessage("Se agrego correctamento el cliente");
      //});
  }
  function updatedLoading() {
    setLoading(false);
    setOpen(true);
  }

  return (
    <React.Fragment>
        <CustomBodyName>
            Agregar un bono
        </CustomBodyName>
        <CustomBodyDescription>
            Este componente se encarga de agregar un bono
        </CustomBodyDescription>
        <CustomBody>
        <CustomMainForm
          title={"Agregue un nuevo bono"}
        >
          <form onSubmit={handleSubmit}>
          <Grid container spacing={3}>
            <Grid item xs={12} sm={6}>
                <CustomTextField
                value={bono.precio}
                onChange={(event) => changeValueBono(event)}
                required
                //Es el atributo el " ... "
                name="precio"
                label="Precio"
                />
            </Grid>
            <Grid item xs={12} sm={6}>
                <CustomTextField
                value={bono.tasaAnual}
                onChange={(event) => changeValueBono(event)}
                required
                //Es el atributo el " ... "
                name="tasaAnual"
                label="Tasa Anual"
                />
            </Grid>
            <Grid item xs={12} sm={6}>
                <CustomTextField
                value={bono.valorNominal}
                onChange={(event) => changeValueBono(event)}
                required
                //Es el atributo el " ... "
                name="valorNominal"
                label="Valor Nominal"
                />
            </Grid>
            <Grid item xs={12} sm={6}>
                <CustomTextField
                value={bono.periodoDePago}
                onChange={(event) => changeValueBono(event)}
                required
                //Es el atributo el " ... "
                name="periodoDePago"
                label="Periodo de Pago"
                />
            </Grid>
            <Grid item xs={12} sm={6}>
                <CustomTextField
                value={bono.nombre}
                onChange={(event) => changeValueBono(event)}
                required
                //Es el atributo el " ... "
                name="nombre"
                label="Nombre"
                />
            </Grid>
            <Grid item xs={12} sm={6}>
                <CustomTextField
                value={bono.tiempo}
                onChange={(event) => changeValueBono(event)}
                required
                //Es el atributo el " ... "
                name="tiempo"
                label="Tiempo restante"
                />
            </Grid>
            <Grid item xs={12} sm={6}>
                <CustomSelect
                value={bono.mercadoPrimario}
                label="¿A que mercado pertenece este bono?"
                onChange={(event) => changeValueBono(event)}
                required
                name="mercadoPrimario"
                helperText="Selecciona un tipo de mercado"
                selection={[
                    {
                        value: true,
                        label: "Mercado primario"
                    },
                    {
                        value: false,
                        label: "Mercado secundario"
                    }
                ]}
                />
            </Grid>
            <Grid item xs={12} sm={6}>
                <CustomSelect
                value={bono.soles}
                label="¿Que moneda se usa en este bono?"
                onChange={(event) => changeValueBono(event)}
                required
                name="soles"
                helperText="Selecciona una moneda"
                selection={[
                    {
                        value: true,
                        label: "Soles"
                    },
                    {
                        value: false,
                        label: "Dolares"
                    }
                ]}
                />
            </Grid>
            
            <Button
                  type={"submit"}
                  variant="contained"
                  color={"primary"}
                  startIcon={<span className="material-icons">Agregar</span>}
                >
            </Button>
         </Grid>
          </form>
        </CustomMainForm>

      </CustomBody>
    </React.Fragment>
  );

}

export default BonoForm;
//export {};