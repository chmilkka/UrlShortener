import { AppBar, Button, Toolbar, Typography } from "@mui/material"
import { useNavigate } from "react-router-dom";

function Header()
{
     const navigate = useNavigate();
    
        const redirectToLogin = () => {
            navigate("/login", { replace: true });
        }
    return (
    <AppBar color= "inherit" position="sticky">
        <Toolbar>
            <Typography variant="h6" sx={{ flexGrow: 1 }}>
            URL Shortener
            </Typography>
            <Button color="inherit">
            About
            </Button>
            <Button color="inherit" onClick={redirectToLogin}>
            Login
            </Button>
      </Toolbar>
    </AppBar>
    );
}
export default Header