import * as React from "react";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";

export default function HeaderComponent() {
  return (
    <Box display="flex" alignItems="center">
      <AppBar position="static">
        <Typography
          variant="h4"
          component="div"
          
          sx={{ textAlign: "center", paddingY: 2 }}
        >
          Data Visualizer
        </Typography>
      </AppBar>
    </Box>
  );
}
