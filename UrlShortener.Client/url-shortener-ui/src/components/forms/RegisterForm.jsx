import React from 'react';
import {  Button, Grid, Paper, TextField } from '@mui/material';
import { useNavigate } from 'react-router-dom';


const RegisterForm=()=>{

    const navigate = useNavigate();

    const redirectToLogin = () => {
        navigate("/login", { replace: true });
    }


    const paperStyle={padding :20,height:'70vh',width:280, margin:"20px auto"}
    const btnstyle={margin:'10px 0'}
    return(
        <Grid>
            <Paper elevation={10} style={paperStyle}>
                <Grid align='center'>                    
                    <h2>Create an account</h2>
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
                <TextField variant='standard' 
                label='Repeat password' 
                placeholder='Repeat password' 
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
                    Create account
                </Button>  
                <Button 
                type='submit' 
                color='inherit' 
                variant="contained" 
                style={btnstyle} 
                fullWidth
                onClick={redirectToLogin}
                >
                    Log In
                </Button>        
            </Paper>
        </Grid>
    )
}

export default RegisterForm