import {
  TextField,
  Box,
  Button,
  Typography,
  CircularProgress,
} from "@mui/material";
import Grid from "@mui/material/Grid";
import axios from "axios";
import { useState } from "react";
import config from "../../config.json";

const StringConverter: React.FC = () => {
  const [valLenght, setValLenght] = useState(0);
  const [strValue, setStrValue] = useState("");
  const [convertedValue, setConvertedValue] = useState("");
  const [errMessage, setErrMessage] = useState("");
  const [isLoading, setIsLoading] = useState(false);

  const fetchConvertedStringLen = async () => {
    try {
      const response = await axios.get(
        `${config.apiBaseUrl}StringConverter/GetConvertedStringLen?Val=${strValue}`
      );

      return response.data;
    } catch (error) {
      console.error("Error fetching results: ", error);
      setErrMessage( "Something went wrong. Please try again.");
    }
  };

  const fetchConvertedStringChar = async (idx: number) => {
    try {
      const response = await axios.get(
        `${config.apiBaseUrl}StringConverter/GetConvertedStringChar?Val=${strValue}&Idx=${idx}`
      );
      console.log("response", response.data);
      return response.data;
    } catch (error) {
      console.error("Error fetching results: ", error);
     setErrMessage( "Something went wrong. Please try again.");
    }
  };

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setStrValue(event.target.value);
    setErrMessage("");
    setConvertedValue("");
  };

  const handleClick = async () => {
    setConvertedValue("");
    if (strValue.length == 0 || strValue === null || strValue === undefined) {
      setErrMessage("Please input a text.");
      return false;
    }

    setIsLoading(true);
    const strLen = await fetchConvertedStringLen();
    console.log("handleClick", strLen);
    if (strLen) {
      let maxLenght = Number(strLen);
      for (let i = 1; i <= maxLenght; i++) {
        const res = await fetchConvertedStringChar(i);
        if (res) {
          setConvertedValue((prev) => prev.concat(res));
        }
      }
    }
    setIsLoading(false);
  };

  return (
    <>
      <Box>
        <Grid container spacing={2}>
          <Grid item xs={12}>
            <Typography
              component="h1"
              variant="h5"
              sx={{ marginBottom: "20px", fontWeight: "bold" }}
            >
              Encode to Base64
            </Typography>
          </Grid>

          <Grid item xs={12}>
            <TextField
              id="outlined-multiline-static"
              label="Text"
              multiline
              rows={4}
              sx={{ width: "100%" }}
              value={strValue}
              onChange={handleInputChange}
            />
          </Grid>

          <Grid item xs={5}></Grid>
          <Grid item xs={2}>
            {isLoading ? (
              <CircularProgress />
            ) : (
              <Button
                type="submit"
                fullWidth
                variant="contained"
                sx={{ mt: 3, mb: 2 }}
                onClick={handleClick}
              >
                Convert
              </Button>
            )}
          </Grid>

          <Grid item xs={5}></Grid>
          <Grid item xs={12}>
            <TextField
              id="outlined-multiline-static"
              label="Based64"
              disabled="true"
              multiline
              rows={4}
              value={convertedValue}
              sx={{ width: "100%" }}
            />
          </Grid>

          <Grid item xs={12}>
            <Typography 
              sx={{ marginBottom: "18px", color: "#CC5500" }}
            >
              {errMessage}
            </Typography>
            
            <Typography 
              sx={{ marginBottom: "18px", color: "#6082B6" }}
            >
              {isLoading ? ("Processing. Please wait") : ("")}
            </Typography>
          </Grid>
        </Grid>
      </Box>
    </>
  );
};

export default StringConverter;
