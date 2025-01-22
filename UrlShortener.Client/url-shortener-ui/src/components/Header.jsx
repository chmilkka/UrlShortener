import { AppBar, Button, Toolbar, Typography } from "@mui/material"
import { useNavigate } from "react-router-dom";
import { useStore } from "../stores/StoresManager";

function Header()
{
     const { userStore } = useStore();
     const navigate = useNavigate();
    
        const redirectToLogin = () => {
            navigate("/login", { replace: true });
        }

        const redirectToAbout = () => {
            navigate("/about", { replace: true });
        }

        const logout = () => {
            navigate('/logout');
        }

    return (
    <AppBar color= "inherit" position="sticky">
        <Toolbar>
            <Typography variant="h6" sx={{ flexGrow: 1 }}>
            URL Shortener
            </Typography>
            <Button color="inherit" onClick={redirectToAbout}>
            About
            </Button>
            <Button color="inherit" onClick={redirectToLogin}>
            Login
            </Button>
            {
                userStore.isLoggedIn
                &&
                <>
                <Button color="inherit" onClick={logout}>Log out</Button>
                </>
            }         
      </Toolbar>
    </AppBar>
    );
}
export default Header