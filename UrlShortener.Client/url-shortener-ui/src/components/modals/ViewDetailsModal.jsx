import { Box, Button, Card, CardMedia, Modal, TextField, Typography } from "@mui/material";
import { useState } from "react";
import { modalStyle } from "./ModalStyle";

  
  export default function ViewDetailsModal() {
    const [open, setOpen] = useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);
  
    return (
      <div>
        <Button variant="contained"
                color="secondary" 
                onClick={handleOpen}>
        View Details
        </Button>
        <Modal
          open={open}
          onClose={handleClose}
          aria-labelledby="modal-modal-title"
          aria-describedby="modal-modal-description"
        >
          <Box sx={{...modalStyle,
              display: "flex",
              alignItems: "center",
              flexDirection: "column",}}>
                 <Box>
                <Typography
                    variant="h5"
                    sx={{ 
                    display: "inline-block",
                    whiteSpace: "nowrap",
                    overflow: "hidden !important",
                    textOverflow: "ellipsis"}}
                >
                 UrlId:
                 <br></br>
                 OriginalUrl:
                 <br></br>
                 ShortenedUrl:
                 <br></br>
                 CreatedAt:
                 <br></br>
                 CreatedBy:
                 <br></br>
                 UserId:      
                </Typography>
            </Box>
          </Box>
        </Modal>
      </div>
    );
  }