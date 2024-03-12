const isEmptyFile = (file) => {
  const filesize = file.size;
  if (filesize === 0) {
    alert("Please input a valid file with data.");
  } else {
    return true;
  }
};

const isFileExist = (files) => {
  const filelength = files.lenght;
  if (filelength === 0) {
    alert("Please upload a valid file.");
  } else {
    return true;
  }
};

const isCorrectExtension = (file) => {
  var filePath = file.name;
  var allowedExtensions = /(\.txt)$/i;

  if (!allowedExtensions.exec(filePath)) {
    alert("Invalid file type.");
    file.value = "";
  } else {
    return true;
  }
};

export { isCorrectExtension, isEmptyFile, isFileExist };
