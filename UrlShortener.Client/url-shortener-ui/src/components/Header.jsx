import { AppBar, Button, Toolbar, Typography } from "@mui/material"

function Header()
{
    return (
    <AppBar color= "inherit" position="sticky">
        <Toolbar>
            <Typography variant="h6" sx={{ flexGrow: 1 }}>
            URL Shortener
            </Typography>
            <Button color="inherit">
            Login
            </Button>
      </Toolbar>
    </AppBar>
    );
}
export default Header