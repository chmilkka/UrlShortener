import React, { useEffect, useRef, useState } from 'react';
import {  Button, Grid, Paper, TextField } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import { useStore } from '../../stores/StoresManager';
import { toast } from 'react-toastify';


const RegisterForm=()=>{

    
   
    const [login, setLogin] = useState('');
    const [loginErrors, setLoginErrors] = useState('');

    const [password, setPassword] = useState('');
    const [passwordErrors, setPasswordErrors] = useState("");

    const [repeatPassword, setRepeatPassword] = useState('');
    const [repeatPasswordErrors, setRepeatPasswordErrors] = useState('');

    const { userStore } = useStore();

    const navigate = useNavigate();

    const firstRender = useRef(true);

    useEffect(() => {
        if (firstRender.current) {
            firstRender.current = false;
            return;
        }
        validateForm();

    }, [ login, password, repeatPassword]);

    const validateForm = () => {
        validateLogin();
        validatePassword();
        validateRepeatPassword();
    }
    const validateLogin = () => {
        if (login.length <= 0) {
            setLoginErrors("Login should be longer than 3 symbols");
        } 
        else 
        {
            setLoginErrors('');
        }
    }

    const validatePassword = () => {
        if (password.length === 0) {
            setPasswordErrors("Fill in the password input");
        } else {
            setPasswordErrors('');
        }
    }

    const validateRepeatPassword = () => {
        if (repeatPassword.length === 0) {
            setRepeatPasswordErrors("Fill in the password input");
        } else if (repeatPassword !== password) {
            setRepeatPasswordErrors("Passwords did not match")
        } else {
            setRepeatPasswordErrors('');
        }
    }

    const hasErrors = () => 
        loginErrors.length 
        || passwordErrors.length 
        || repeatPasswordErrors.length;

    const submit = async () => {
        if (hasErrors()) {
            return;
        }
        const user = {
            login: login, 
            password: password,
        };
        try {
             await userStore.register(user); 
            toast.success("Your account has been successfully registered!")
            redirectToLogin(); 
            
        } catch (error) {
            toast.error(error.response.data.error)
        }
            
    }
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
                value={login}
                helperText={loginErrors}
                error={loginErrors.length !== 0}
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
                helperText={passwordErrors}
                error={passwordErrors.length !== 0}
                aria-required="true"
                onChange={e => setPassword(e.target.value)}
                /> 
                <TextField variant='standard' 
                label='Repeat password' 
                placeholder='Repeat password' 
                type='password' 
                fullWidth required            
                value={repeatPassword}
                helperText={repeatPasswordErrors}
                error={repeatPasswordErrors.length !== 0}
                aria-required="true"
                onChange={e => setRepeatPassword(e.target.value)}
                />      
                <Button 
                type='submit' 
                color='inherit' 
                variant="contained" 
                style={btnstyle} 
                fullWidth
                onClick={submit}
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