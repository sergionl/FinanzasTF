import React from "react";
import { Divider, Grid, Paper, Typography } from "@material-ui/core";

interface Props {
  children?: React.ReactNode;
}

function CustomBodyName({ children }: Props) {
  return (
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
          {children}
        </Typography>
      </Paper>
    </Grid>
  );
}

export default CustomBodyName;
