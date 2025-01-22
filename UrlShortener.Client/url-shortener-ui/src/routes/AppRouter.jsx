import React from 'react';
import { Navigate, Route, Routes } from 'react-router-dom';
import LoginPage from '../pages/LoginPage';
import RegisterPage from '../pages/RegisterPage';
import NotFoundPage from '../pages/NotFoundPage';

const AllRoutes = () => {
    return (
        <Routes>
            <Route index replace element={<Navigate to="/login"/>}/>
            <Route path ="/login" element={<LoginPage/>}/>
            <Route path ="/register" element={<RegisterPage/>}/>         
            <Route path='*'element={<NotFoundPage/>}/>
        </Routes>          
    );
};

export default AllRoutes;