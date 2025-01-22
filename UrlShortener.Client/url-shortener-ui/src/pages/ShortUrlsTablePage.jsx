import React from "react";
import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  Button,
} from "@mui/material";

const ShortUrlsTablePage = () => {
    return (
    <TableContainer component={Paper} style={{ marginTop: "20px" }}>
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>Original URL</TableCell>
            <TableCell>Shortened URL</TableCell>
            <TableCell align="center">Actions</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
            <TableRow>
              <TableCell>dddddddddd</TableCell>
              <TableCell>
                <a  target="_blank" rel="noopener noreferrer">
                    ssssssssssss
                </a>
              </TableCell>
                <TableCell align="center">
                  <Button
                    variant="contained"
                    color="primary"
                    style={{ marginRight: "10px" }}
                  >
                    View Details
                  </Button>
                  <Button
                    variant="contained"
                    color="secondary"
                  >
                    Delete
                  </Button>
                </TableCell>
            </TableRow>
        </TableBody>
      </Table>
    </TableContainer>
  );
}
export default ShortUrlsTablePage;