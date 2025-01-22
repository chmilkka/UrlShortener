
import React, { useState } from 'react';
import {  Button, Grid, Paper, TextField } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import { useStore } from '../../stores/StoresManager';
import { toast } from 'react-toastify';

const LoginForm=()=>{ 
    const [login, setLogin] = useState("");
    const [password, setPassword] = useState("");

    const { userStore } = useStore();

    const submit = async () => {
       

        const user = 
        { 
            login: login, 
            password: password 
        };
       
        try 
        {
             await userStore.login(user);
             redirectToUrls();
        } 
        catch (error) 
        {
            console.log(error)
            toast.error(error.response.data.error)
        }
    };

    
    const navigate = useNavigate();

    const redirectToUrls = () => {
        navigate("/urls", { replace: true });
    }
    
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
                value={login}
                aria-required="true"
                onChange={e => setLogin(e.target.value)}
                />
               <TextField 
                variant='standard' 
                label='Password' 
                placeholder='Enter password' 
                type='password' 
                fullWidth required
                value={password}
                aria-required="true"
                onChange={e => setPassword(e.target.value)}
                /> 
                <Button 
                type='submit' 
                color='inherit' 
                variant="contained" 
                style={btnstyle} 
                fullWidth
                onClick={submit}
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
