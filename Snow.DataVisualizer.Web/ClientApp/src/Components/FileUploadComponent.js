import React, { useState } from "react";
import Toolbar from "@mui/material/Toolbar";
import Box from "@mui/material/Box";
import { isCorrectExtension, isEmptyFile, isFileExist } from "../utils/Utils";
import Button from "@mui/material/Button";
import { Typography } from "@mui/material";
import CheckIcon from "@mui/icons-material/Check";

export const FileUploadComponent = (props) => {
  const [fileSelected, setFileSelected] = useState();
  const [displayText, setDisplayText] = useState("Choose File to upload");
  const [validation, setValidation] = useState(false);

  const selectFileHandler = (e) => {
    var validation = isFileExist(e.target.files);
    var validation2 = isEmptyFile(e.target.files[0]);
    var validation3 = isCorrectExtension(e.target.files[0]);
    if (validation && validation2 && validation3) {
      setFileSelected(e.target.files[0]);
      setDisplayText(e.target.files[0].name);
      setValidation(true);
    }
  };

  const uploadFileHandler = async (e) => {
    props.setLoading(true);
    const formData = new FormData();
    formData.append("file", fileSelected);
    setValidation(false);

    fetch("https://localhost:7128/api/FileUpload/ImportFile", {
      method: "POST",
      body: formData,
    })
      .then((response) => response.json())
      .then((data) => props.setBarData(data))
      .then((success) => {
        console.log(success);
        props.setLoading(false);
      })
      .catch((error) => {
        console.error(error);
        alert("Data provided is not valid.");
        props.setLoading(false);
        props.setBarData([]);
      });
  };

  return (
    <>
      <Box display="flex" alignItems="center">
        <Toolbar sx={{ m: "auto", p: 1 }}>
          <label htmlFor="upload-file">
            <input
              style={{ display: "none" }}
              id="upload-file"
              name="upload-file"
              type="file"
              onChange={selectFileHandler}
            />

            <Button color="primary" variant="outlined" component="span">
              Select File
            </Button>
          </label>
          <Typography
            id="file-name"
            variant="h6"
            width={400}
            sx={{ p: 1, m: 1 }}
          >
            {displayText}
          </Typography>
          {validation ? <CheckIcon /> : null}

          <Button
            value="upload"
            color="primary"
            variant="contained"
            onClick={uploadFileHandler}
            disabled={!validation}
          >
            Upload File
          </Button>
        </Toolbar>
        ;
      </Box>
    </>
  );
};
