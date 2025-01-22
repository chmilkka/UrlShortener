import React from 'react';
import { Navigate, Route, Routes } from 'react-router-dom';
import LoginPage from '../pages/LoginPage';

const AllRoutes = () => {
    return (
        <Routes>
            <Route index replace element={<Navigate to="/login"/>}/>
            <Route path ="/login" element={<LoginPage/>}/>         
            <Route path='*'/>
        </Routes>          
    );
};

export default AllRoutes;