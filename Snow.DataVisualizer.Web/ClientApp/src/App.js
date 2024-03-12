import React, { useState, useEffect } from "react";
import HeaderComponent from "./Components/HeaderComponent";
import {FileUploadComponent} from "./Components/FileUploadComponent";
import "./custom.css";
import BarChartComponent from "./Components/BarChartComponent";

export default function App() {
  const [barData, setBarData] = useState([]);
  const [loading, setLoading] = useState(false);

  const getRandomData = async (e) => {
    fetch("https://localhost:7128/api/FileUpload/DataRandomizer")
      .then((response) => response.json())
      .then((data) => setBarData(data))
      .then((success) => console.log(success))
      .catch((error) => console.log(error));
  };
  useEffect(() => {
    setInterval(() => {
      getRandomData();
    }, 60000);
  }, []);

  return (
    <React.StrictMode>
      <HeaderComponent />
      <FileUploadComponent setBarData={setBarData} setLoading={setLoading} />
      <BarChartComponent barData={barData} loading={loading} />
    </React.StrictMode>
  );
}
