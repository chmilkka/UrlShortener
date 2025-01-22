
import React from 'react';
import {  Button, Grid, Paper, TextField } from '@mui/material';
import { useNavigate } from 'react-router-dom';

const LoginForm=()=>{ 
    
    const navigate = useNavigate();
    
        const redirectToRegister = () => {
            navigate("/register", { replace: true });
        }
    
    const paperStyle={padding :20,height:'70vh',width:280, margin:"20px auto"}
    const btnstyle={margin:'10px 0'}
    return(
        <Grid>
            <Paper elevation={10} style={paperStyle}>
                <Grid align='center'>                    
                    <h2>Log in to your account</h2>
                </Grid>
                <TextField 
                variant='standard'
                label='Login' 
                placeholder='Enter your login' 
                fullWidth required
                aria-required="true"
                />
               <TextField 
                variant='standard' 
                label='Password' 
                placeholder='Enter password' 
                type='password' 
                fullWidth required
                aria-required="true"
                /> 
                <Button 
                type='submit' 
                color='inherit' 
                variant="contained" 
                style={btnstyle} 
                fullWidth
                >
                    Log in</Button> 
                <Button 
                type='submit' 
                color='inherit' 
                variant="contained" 
                style={btnstyle} 
                fullWidth
                onClick={redirectToRegister}
                >
                    Register
                </Button>         
            </Paper>
        </Grid>
    )
}

export default LoginForm
