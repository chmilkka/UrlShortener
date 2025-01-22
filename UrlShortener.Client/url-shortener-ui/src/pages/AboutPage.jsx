import React from "react";
import { Typography, Box } from "@mui/material";

const AboutPage = () => {
  return (
    <Box sx={{ padding: "20px", maxWidth: "800px", margin: "0 auto" }}>
      <Typography variant="h4" sx={{ marginBottom: "20px" }}>
        About URL Shortener
      </Typography>
      <Typography variant="body1" sx={{ marginBottom: "20px" }}>
      The algorithm of my URL shortening service is quite simple yet reliable. 
      When a user submits a long URL to shorten, the system generates a unique short code.
      This code is created using a built-in method that generates a GUID, which is a globally unique identifier. 
      The first 6 characters of the GUID are taken to make the link compact. 
      This approach ensures that the chance of generating the same code twice is practically zero.
      <p/>
      Next, the short code is appended to the base URL of my service, for example, https://localhost:5000/. 
      As a result, a complete shortened link is created, such as https://localhost:5000/abc123.
      When a user clicks on this link, the service checks the database to find the original URL associated with 
      it and automatically redirects the user to the desired website.
      </Typography>
    </Box>
  );
};

export default AboutPage;