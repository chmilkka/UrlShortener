import React, { useEffect, useRef, useState } from "react";
import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  Button,
  TextField,
} from "@mui/material";
import ViewDetailsModal from "../components/modals/ViewDetailsModal";
import { useStore } from "../stores/StoresManager";
import { toast } from "react-toastify";

const ShortUrlsTablePage = () => {

const [originalUrl, setOriginalUrl] = useState('');
const [originalUrlErrors, setOriginalUrlErrors] = useState('');

const { urlStore } = useStore();
const { userStore } = useStore();
const { commonStore } = useStore();

const firstRender = useRef(true);

    useEffect(() => {
        if (firstRender.current) {
            firstRender.current = false;
            return;
        }
        validateUrl();
    });

    const validateUrl = () => {
        if (originalUrl.length <= 0) {
            setOriginalUrlErrors("URL should be longer");
        } 
        else 
        {
            setOriginalUrlErrors('');
        }
    }

     const hasErrors = () =>  originalUrlErrors.length 
            
        const submit = async () => {
            if (hasErrors()) {
                return;
            }
            userStore.getUserIdFromJwt(commonStore.token)
            const createUrlDto = {
                originalUrl: originalUrl, 
                userId: userStore.userId,
            };
            try {
                await urlStore.createShortUrl(createUrlDto); 
                toast.success("Short URL successfull created!")              
            } catch (error) 
            {
                toast.error(error.response.data.error)
            }
                
        }

    return (
    <TableContainer component={Paper} style={{ marginTop: "20px" }}>
        {userStore.isLoggedIn && (
        <div style={{ display: "flex", gap: "10px", marginBottom: "10px" }}>
          <TextField
            variant="standard"
            label="Original URL"
            placeholder="Enter your URL"
            value={originalUrl}
            aria-required="true"
            onChange={(e) => setOriginalUrl(e.target.value)}
          />
          <Button variant="contained" color="success" onClick={submit}>
            Create Short URL
          </Button>
        </div>
      )}
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
                    <ViewDetailsModal>                      
                    </ViewDetailsModal>       
                  <Button
                    variant="contained"
                    color="error"
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