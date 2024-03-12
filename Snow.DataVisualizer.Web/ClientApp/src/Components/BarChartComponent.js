import React from "react";
import { Box } from "@mui/material";
import { BarChart } from "@mui/x-charts/BarChart";
import LoadingComponent from "./LoadingComponent";

export default function BarChartComponent(props) {
  const series = props.barData.map((x) => {
    return {
      label: x.name,
      data: [x.value],
    };
  });

  if (props.loading) return <LoadingComponent message="Loading Data..." />;

  return (
    <Box display="flex" alignItems="center">
      <BarChart
        xAxis={[{ scaleType: "band", data: ["1"] }]}
        series={series}
        colors={props.barData.map((x) => x.colorHex)}
        width={900}
        height={600}
      />
    </Box>
  );
}
